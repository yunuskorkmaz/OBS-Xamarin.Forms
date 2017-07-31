using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using OBS.Droid;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(CustomEntryBorderRenderer))]
namespace OBS.Droid
{
    public class CustomEntryBorderRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var nativeEditText = (global::Android.Widget.EditText)Control;
            var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
            shape.Paint.Color = Xamarin.Forms.Color.Transparent.ToAndroid();
            shape.Paint.SetStyle(Paint.Style.Stroke);
            nativeEditText.Background = shape;
        }
    }
}