package net.wagsn.note.edit;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import net.wagsn.note.R;
import net.wagsn.note.list.NoteItem;
import net.wagsn.note.list.NoteListStore;
import net.wagsn.note.list.NoteRefList;

import java.util.Objects;
import java.util.concurrent.atomic.AtomicReference;

/**
 * A placeholder fragment containing a simple view.
 */
public class NoteEditFragment extends Fragment {

    private static final String TAG = "NoteEditFragment";

    private ViewHolder holder;
    private static final String NOTE_ITEM = "NOTE_ITEM";

    public NoteEditFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.edit_fragment, container, false);
        holder = new ViewHolder(view);

        if(savedInstanceState!=null){
            holder.item = (NoteItem) savedInstanceState.get(NOTE_ITEM);
        }
        return view;
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

    public void save(){
        NoteItem item = holder.getItem();
        NoteListStore.get().add(item);
        Log.d(TAG, "save: "+item);
        Objects.requireNonNull(getActivity()).finish();
    }

    public void show(String id){
        NoteListStore.get().stream().filter(n -> n.id.equals(id)).findFirst().ifPresent(item -> holder.setItem(item));
    }
}
