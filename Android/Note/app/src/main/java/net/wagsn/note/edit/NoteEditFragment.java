package net.wagsn.note.edit;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import net.wagsn.note.R;
import net.wagsn.note.entity.NoteItem;
import net.wagsn.note.list.NoteListStore;
import net.wagsn.util.PerformEdit;

import org.greenrobot.eventbus.EventBus;
import org.greenrobot.eventbus.Subscribe;

/**
 * A placeholder fragment containing a simple view.
 */
public class NoteEditFragment extends Fragment {

    private static final String TAG = "NoteEditFragment";

    private ViewHolder holder;
    PerformEdit mPerformEdit;
    private static final String NOTE_ITEM = "NOTE_ITEM";

    public NoteEditFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.edit_fragment, container, false);
        holder = new ViewHolder(view);

        mPerformEdit = new PerformEdit(holder.contentView);

        if(savedInstanceState!=null){
            holder.item = (NoteItem) savedInstanceState.get(NOTE_ITEM);
        }

        EventBus.getDefault().register(this);

        return view;
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        inflater.inflate(R.menu.menu_editor_frag, menu);
        super.onCreateOptionsMenu(menu, inflater);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_undo://撤销
                mPerformEdit.undo();
                return true;
            case R.id.action_redo://重做
                mPerformEdit.redo();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        EventBus.getDefault().unregister(this);
    }

    public static class ViewHolder {

        EditText titleView;
        EditText contentView;

        NoteItem item = new NoteItem();

        public ViewHolder(View view){
            titleView = view.findViewById(R.id.note_title);
            contentView =view.findViewById(R.id.note_content);
        }

        public NoteItem getItem(){
            item.title = titleView.getText().toString();
            item.content = contentView.getText().toString();
            return item;
        }

        public void setItem(NoteItem item) {
            this.item = item;
            titleView.setText(item.title);
            contentView.setText(item.content);
        }
    }

    @Subscribe
    public void save(NoteEditActivity.NoteSaveEvent event){
        NoteItem item = holder.getItem();
        NoteListStore.get().add(item);
        Log.d(TAG, "save: "+item);
        if (getActivity()!=null){
            getActivity().finish();
        }
    }

    @Subscribe
    public void show(NoteEditActivity.NoteShowEvent event){
        NoteListStore.get().stream().filter(n -> n.id.equals(event.id)).findFirst().ifPresent(item -> holder.setItem(item));
    }
}
