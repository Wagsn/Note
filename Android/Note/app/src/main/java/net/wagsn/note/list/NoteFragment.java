package net.wagsn.note.list;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import net.wagsn.note.R;
import net.wagsn.note.storage.NoteStore;

/**
 * A fragment representing a list of Items.
 * View for Note List.
 */
public class NoteFragment extends Fragment {

    private static final String ARG_COLUMN_COUNT = "column-count";
    private int mColumnCount = 1;
    private NoteRecyclerViewAdapter adapter;
    private NoteListStore store = NoteListStore.get();

    /**
     * Mandatory empty constructor for the fragment manager to instantiate the
     * fragment (e.g. upon screen orientation changes).
     */
    public NoteFragment() {
    }

    // TODO: Customize parameter initialization
    @SuppressWarnings("unused")
    public static NoteFragment newInstance(int columnCount) {
        NoteFragment fragment = new NoteFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_COLUMN_COUNT, columnCount);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (getArguments() != null) {
            mColumnCount = getArguments().getInt(ARG_COLUMN_COUNT);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.note_list, container, false);

        // Set the adapter
        if (view instanceof RecyclerView) {
            Context context = view.getContext();
            RecyclerView recyclerView = (RecyclerView) view;
            if (mColumnCount <= 1) {
                recyclerView.setLayoutManager(new LinearLayoutManager(context));
            } else {
                recyclerView.setLayoutManager(new GridLayoutManager(context, mColumnCount));
            }
//            NoteContent.clear();
//            NoteContent.ITEMS.addAll(NoteStore.get().loadAll());
//            adapter = new NoteRecyclerViewAdapter(NoteContent.ITEMS);
            adapter = new NoteRecyclerViewAdapter(store);
            recyclerView.setAdapter(adapter);
        }
        return view;
    }

    @Override
    public void onResume() {
        super.onResume();

        // TODO replace to NoteStore, move to Presenter. presenter.resume();
//        NoteContent.ITEMS.clear();
//        NoteContent.ITEMS.addAll(NoteStore.get().loadAll());  // Store.get().loadAll<NoteItem>();
        adapter.notifyDataSetChanged();
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }
}
