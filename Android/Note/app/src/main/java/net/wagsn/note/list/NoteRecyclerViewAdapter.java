package net.wagsn.note.list;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import net.wagsn.note.R;
import net.wagsn.note.edit.NoteEditActivity;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

/**
 * {@link RecyclerView.Adapter} that can display a {@link NoteItem} and makes a call to the
 * specified {@link NoteRecyclerViewAdapter.ViewHolder.OnClickListener}.
 * Presenter for Note List.
 */
public class NoteRecyclerViewAdapter extends RecyclerView.Adapter<NoteRecyclerViewAdapter.ViewHolder> {

    // Model
    private final List<NoteItem> mValues;
//    private final NoteStore store = NoteStore.get();

    NoteRecyclerViewAdapter(List<NoteItem> items) {
        mValues = items;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.note_row, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {
        holder.setData(mValues.get(position));
    }

    @Override
    public int getItemCount() {
        return mValues.size();
    }

    /**
     * Item View Holder, with item data, as Presenter.
     */
    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener, View.OnLongClickListener {
        private static final String TAG = "ViewHolder";
        // Item View
        final View mView;
        final TextView mIdView;
        final TextView mTitleView;
        final TextView mContentView;
        final TextView mTimeView;
        final String timePattern = "yyyy/MM/dd HH:mm:ss";
        @SuppressLint("SimpleDateFormat")
        final SimpleDateFormat dateFormat = new SimpleDateFormat(timePattern);
        NoteItem mItem;

        ViewHolder(View view) {
            super(view);
            mView = view;
            mIdView = view.findViewById(R.id.note_id);
            mTitleView = view.findViewById(R.id.note_title);
            mContentView =  view.findViewById(R.id.note_content);
            mTimeView = view.findViewById(R.id.note_time);
            mView.setOnClickListener(this);
            mView.setOnLongClickListener(this);
        }

        public void setData(NoteItem item){
            mItem = item;
            mIdView.setText(mItem.id);
            mTitleView.setText(mItem.title);
            if(mItem.content.isEmpty())
                mContentView.setVisibility(View.GONE);
            else
                mContentView.setVisibility(View.VISIBLE);
            mContentView.setText(mItem.content);
            mTimeView.setText(dateFormat.format(mItem.time==null?new Date():mItem.time));
        }

        @Override
        public String toString() {
            return super.toString() + " '" + mContentView.getText() + "'";
        }

        @Override
        public void onClick(View v) {
            Log.d(TAG, "onClick: 在ViewHolder中的ItemView点击监听");
            Intent intent = new Intent(mView.getContext(), NoteEditActivity.class);
            intent.putExtra("NOTE_ITEM", mItem.id);
            mView.getContext().startActivity(intent);
        }

        @Override
        public boolean onLongClick(View v) {
            Log.d(TAG, "onLongClick: 在ViewHolder中的ItemView长按监听");
            return false;
        }

        public interface OnClickListener {
            void onClick(ViewHolder holder);
        }

        public interface OnLongClickListener {
            void onLongClick(ViewHolder holder);
        }
    }
}
