#include "World.h"

GtkWidget* window;
GtkWidget* darea; 
World* world;

static gboolean 
  on_expose_event(GtkWidget *widget, GdkEventExpose *event, gpointer data)
{
  cairo_t* cr = gdk_cairo_create(darea->window);
  world->Evolve(cr);      
  return FALSE;
}

int main(int argc, char* argv[])
{
  gtk_init(&argc, &argv);
  GtkWidget* window = gtk_window_new(GTK_WINDOW_TOPLEVEL);
  gtk_widget_set_usize(window, 640, 480);  
  g_signal_connect(G_OBJECT(window), "destroy", G_CALLBACK(gtk_main_quit), NULL);   
  gtk_window_set_title(GTK_WINDOW(window), "Game Of Life");
  int worldSize = 150;
  world = new World(150, 150);
  world->Seed(25, 640.0 / worldSize, 480.0 / worldSize);
  darea = gtk_drawing_area_new();
  gtk_container_add(GTK_CONTAINER(window), darea);
  g_signal_connect(darea, "expose-event", G_CALLBACK(on_expose_event), NULL);
  gtk_widget_show_all(window);
  gtk_main();
  return 0;
}