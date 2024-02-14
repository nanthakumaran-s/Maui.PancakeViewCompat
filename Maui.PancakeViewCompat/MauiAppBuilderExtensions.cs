namespace PancakeView;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UsePancakeViewCompat(this MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers((handlers) =>
        {
#if ANDROID
            handlers.AddHandler(typeof(PancakeView), typeof(Maui.PancakeView.Droid.PancakeViewRenderer));
#elif IOS
            handlers.AddHandler(typeof(PancakeView), typeof(Maui.PancakeView.iOS.PancakeViewRenderer));
#endif
        });

        return builder;
    }

}
