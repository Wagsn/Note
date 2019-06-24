package net.wagsn.note.list;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Helper class for providing sample content for user interfaces created by
 * Android template wizards.
 */
public class NoteContent {

    /**
     * An array of sample (dummy) items.
     */
    public static final List<NoteItem> ITEMS = new ArrayList<>();

    /**
     * A map of sample (dummy) items, by ID.
     */
    public static final Map<String, NoteItem> ITEM_MAP = new HashMap<>();

    private static final int COUNT = 25;

    static {
        // Add some sample items.
//        for (int i = 1; i <= COUNT; i++) {
//            addItem(createDummyItem(i));
//        }
    }

    public void replaceAll(){

    }

    public static void clear(){
        ITEMS.clear();
        ITEM_MAP.clear();
    }

    public static void addItem(NoteItem item) {
        ITEMS.add(item);
        ITEM_MAP.put(item.id, item);
    }
}
