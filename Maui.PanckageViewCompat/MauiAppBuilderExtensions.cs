using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.PancakeView;

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
