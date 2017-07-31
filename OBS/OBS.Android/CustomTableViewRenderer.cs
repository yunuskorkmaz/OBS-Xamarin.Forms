using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using OBS.Droid;

//[assembly: ExportRenderer(typeof(TableView), typeof(CustomTableViewRenderer))]

namespace OBS.Droid
{
    public class CustomTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            Control.Divider = new ColorDrawable(Android.Graphics.Color.Transparent);
            Control.Divider = null;
            Control.DividerHeight = 0;
            Control.SetHeaderDividersEnabled(false);
        }
    }
}