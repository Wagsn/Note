package net.wagsn.note.activity;

import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.view.MenuItem;

import net.wagsn.note.R;
import net.wagsn.note.about.AboutActivity;
import net.wagsn.note.login.ui.LoginActivity;
import net.wagsn.util.binding.Bind;
import net.wagsn.util.binding.ViewBinder;

public class NavigationViewExecutor implements NavigationView.OnNavigationItemSelectedListener {

    MainActivity activity;
    @Bind(R.id.drawer_layout)
    private DrawerLayout drawer;
    @Bind(R.id.nav_view)
    private NavigationView navigationView;

    NavigationViewExecutor(MainActivity activity){
        this.activity =activity;
        ViewBinder.bind(this, activity.getWindow().getDecorView());

        navigationView.setNavigationItemSelectedListener(this);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if(id == R.id.nav_login){
            startActivity(LoginActivity.class);
        }
        if (id == R.id.nav_about) {
            startActivity(AboutActivity.class);
        }
        if (id == R.id.nav_home) {
            // Handle the camera action
        } else if (id == R.id.nav_gallery) {

        } else if (id == R.id.nav_slideshow) {

        } else if (id == R.id.nav_tools) {

        } else if (id == R.id.nav_share) {

        } else if (id == R.id.nav_send) {

        }

        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

    private void startActivity(Class<?> cls) {
        Intent intent = new Intent(activity, cls);
        activity.startActivity(intent);
    }
}
