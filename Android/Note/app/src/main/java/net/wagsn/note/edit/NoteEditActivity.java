package net.wagsn.note.edit;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;

import net.wagsn.note.R;

import java.util.Objects;

public class NoteEditActivity extends AppCompatActivity {

    private static final String TAG = "NoteEditActivity";

    private NoteEditFragment mNoteEditFragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.edit_activity);

        Log.d(TAG, "onCreate: "+mNoteEditFragment);
        String id = getIntent().getStringExtra("NOTE_ITEM");

        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        mNoteEditFragment =(NoteEditFragment) getSupportFragmentManager().findFragmentById(R.id.fragment);
        Objects.requireNonNull(mNoteEditFragment).show(id);

        FloatingActionButton fab = findViewById(R.id.fab);
        fab.setOnClickListener(view -> {
            mNoteEditFragment.save();
        });
    }
}
