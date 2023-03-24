using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Work;
using Java.Util.Concurrent;

namespace BulgarskiLetobroj
{
    /// <summary>
    /// Widget provider implementation configured as the application widget.
    /// Contains static list of widgets and their dimentions.
    /// Overrides OnUpdate, OnAppWidgetOptionsChanged, OnReceive to update widget view.
    /// </summary>
    // + Exported attribute for new androids
    [BroadcastReceiver(Label = "Български лѣтоброй", Icon = "@drawable/previewImage", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
	[MetaData("android.appwidget.provider", Resource = "@xml/appwidgetprovider")]
	public class AppWidget : AppWidgetProvider
	{
        static readonly Dictionary<int, int> mWidgets = new Dictionary<int, int>();
        static readonly Dictionary<int, int> mDetails = new Dictionary<int, int>();
        string[] weekNames = new string[] { "първи", "втори", "трети", "четвърти", "пети", "шести", "седми" };
        string[] elements = new string[] { "вода", "огън", "земя", "дърво", "метал" };
        string[] genders = new string[] { "мъжки", "женска" };
        string[] animalst = new string[] { "докс", "сомор", "шегор", "барс", "дванш", "вер", "дилом", "тек", "песин", "суръх", "тох", "етх" };
        string[] animalsm = new string[] { "прасе", "мишок", "вол", "барс", "заек", "змей", "змия", "кон", "маймуна", "овен", "петел", "куче" };
        string[] animalsf = new string[] { "свиня", "мишка", "биволица", "барс", "зайкѝня", "ламя", "змия", "кобила", "маймуна", "овца", "кокошка", "кучка" };
        string[] colors = new string[] { "черно", "червено", "жълто", "синьо", "бяло" };
        string[] directions = new string[] { "среда", "юг", "запад", "север", "изток" };

        /// <summary>
        /// Called from the AppWidgetProvider.
        /// </summary>
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
		{
            try
            {
                Console.WriteLine("letobrojdebug Update " + string.Join(", ", appWidgetIds));
                var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
			    foreach(int widget in appWidgetIds)
                {
                    Console.WriteLine("letobrojdebug Update one " + widget);
                    appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, widget));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("letobrojdebug " + ex.Message);
                Console.WriteLine("letobrojdebug " + ex.StackTrace);
                Console.WriteLine("letobrojdebug " + ex.Source);
            }
        }
        /// <summary>
        /// Called when widget is being resized.
        /// </summary>
        public override void OnAppWidgetOptionsChanged(Context context, AppWidgetManager appWidgetManager, int appWidgetId, Bundle newOptions)
        {
            Console.WriteLine("letobrojdebug Options " + appWidgetId);
            try
            {
                base.OnAppWidgetOptionsChanged(context, appWidgetManager, appWidgetId, newOptions);
            var maxWidth = newOptions.Get("appWidgetMaxWidth");
            var maxHeight = newOptions.Get("appWidgetMaxHeight");
            var minWidth = newOptions.Get("appWidgetMinWidth");
            var minHeight = newOptions.Get("appWidgetMinHeight");
            //if (sizes == null)// || sizes.Count == 0)
            //{
            //    return;
            //}

            Console.WriteLine(minWidth + "x" + minHeight + " " + maxWidth + "x" + maxHeight);
                mDetails[appWidgetId] = 0;

                if (mDetails.ContainsKey(appWidgetId) == false)
                {
                    mWidgets.Add(appWidgetId, Resource.Layout.Widget_1_1);
                    mDetails.Add(appWidgetId, 0);
                }

                if ((double)minWidth < 200 && (double)minHeight < 200)
                {
                    mWidgets[appWidgetId] = Resource.Layout.Widget_1_1;
                    mDetails[appWidgetId] = 0;
                }
                else if ((double)minWidth < 200)
                {
                    mWidgets[appWidgetId] = Resource.Layout.Widget_1_2;
                    mDetails[appWidgetId] = 0;
                }
                else if ((double)minHeight < 200)
                {
                    mWidgets[appWidgetId] = Resource.Layout.Widget_2_1;
                    mDetails[appWidgetId] = 2;
                }
                else
                {
                    mWidgets[appWidgetId] = Resource.Layout.Widget_2_2;
                    mDetails[appWidgetId] = 2;
                }
                var widgetView = new RemoteViews(context.PackageName, mWidgets[appWidgetId]);

                SetTextViewText(appWidgetId, widgetView);
                //            RegisterClicks(context, new int[] { CurrentWidget }, widgetView);

                //var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
                appWidgetManager.UpdateAppWidget(appWidgetId, widgetView);
            }
            catch (Exception ex)
            {
                Console.WriteLine("letobrojdebug " + ex.Message);
                Console.WriteLine("letobrojdebug " + ex.StackTrace);
                Console.WriteLine("letobrojdebug " + ex.Source);
            }
        }
        /// <summary>
        /// Builds the remote view in question
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="appWidgetId">App widget to build</param>
        /// <returns>The RemoteView with set texts and registered clicks</returns>
        private RemoteViews BuildRemoteViews(Context context, int appWidgetId)
		{
            if (mDetails.ContainsKey(appWidgetId) == false)
            {
                mWidgets.Add(appWidgetId, Resource.Layout.Widget_1_1);
                mDetails.Add(appWidgetId, 0);
            }
            
            // Retrieve the widget layout. This is a RemoteViews, so we can't use 'FindViewById'
            var widgetView = new RemoteViews(context.PackageName, mWidgets[appWidgetId]);

            Console.WriteLine("letobrojdebug Build remote " + appWidgetId + " -> " + mWidgets[appWidgetId]);
            SetTextViewText(appWidgetId, widgetView);
			RegisterClicks(context, new int[] { appWidgetId }, widgetView);

			return widgetView;
		}
        /// <summary>
        /// Sets the texts of the desired widget
        /// </summary>
        /// <param name="widgetId">Widget id to work on</param>
        /// <param name="widgetView">RemoteView</param>
		private void SetTextViewText(int widgetId, RemoteViews widgetView)
		{
            Letobroj l = new Letobroj();
            var n = DateTime.Now;
            var r = l.GetDay(n);

            if(mDetails.ContainsKey(widgetId) == false)
            {
                mWidgets.Add(widgetId, Resource.Layout.Widget_1_1);
                mDetails.Add(widgetId, 0);
            }

			if (mDetails[widgetId] == 0)
			{
				widgetView.SetTextViewText(Resource.Id.widgetDay, (r.Day + 1) + "." + (r.Month + 1) + "." + (r.Year + 1));
			}
			else
			{
                widgetView.SetTextViewText(Resource.Id.widgetDay, (r.Day + 1).ToString());
            }

            widgetView.SetTextViewText(Resource.Id.widgetMonth, (r.Month + 1).ToString());
            widgetView.SetTextViewText(Resource.Id.widgetYear, (r.Year + 1).ToString());
			if (r.behti)
			{
				widgetView.SetTextViewText(Resource.Id.widgetWeekday, "Ден бехти");
                widgetView.SetTextViewText(Resource.Id.widgetMonth, "");
				if(mDetails[widgetId] == 0)
				{ 
	                widgetView.SetTextViewText(Resource.Id.widgetDay, (r.Year + 1).ToString());
                }
                else
                {
                    widgetView.SetTextViewText(Resource.Id.widgetDay, "");
                }
            }
            else if (r.eni)
			{
                widgetView.SetTextViewText(Resource.Id.widgetWeekday, "Ден ени");
				if (mDetails[widgetId] == 0)
				{
					widgetView.SetTextViewText(Resource.Id.widgetDay, (r.Year + 1).ToString());
				}
				else
				{
                    widgetView.SetTextViewText(Resource.Id.widgetDay, "");
                }
                widgetView.SetTextViewText(Resource.Id.widgetMonth, "");
            }
            else
			{
                widgetView.SetTextViewText(Resource.Id.widgetWeekday, "Ден " + weekNames[r.WeekDay] + " от седем");
            }

            widgetView.SetTextViewText(Resource.Id.widgetSDay, (r.StarDay + 1).ToString());
            widgetView.SetTextViewText(Resource.Id.widgetSWeek, (r.StarWeek + 1).ToString());
            widgetView.SetTextViewText(Resource.Id.widgetSMonth, (r.StarMonth + 1).ToString());
            widgetView.SetTextViewText(Resource.Id.widgetSYear, (r.StarYear + 1).ToString());
            widgetView.SetTextViewText(Resource.Id.widgetSEra, (r.StarEpoch + 1).ToString());

            widgetView.SetTextViewText(Resource.Id.widgetElement, elements[r.DouzineElement] + ", " + colors[r.DouzineElement] + ", " + directions[r.DouzineElement]);
            widgetView.SetTextViewText(Resource.Id.widgetGender, animalsf[r.DozenAnimal] == animalsm[r.DozenAnimal] ? genders[r.DouzineGender] : "");
            widgetView.SetTextViewText(Resource.Id.widgetAnimal, (r.DouzineGender == 0 ? animalsf[r.DozenAnimal] : animalsm[r.DozenAnimal]) + (animalst[r.DozenAnimal] != animalsm[r.DozenAnimal] ? " (" + animalst[r.DozenAnimal] + ")" : ""));
        }
        /// <summary>
        /// Registers clicks on the widget
        /// </summary>
        private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
		{
            Console.WriteLine("letobrojdebug RegisterClicks ");
            var intent = new Intent(context, typeof(AppWidget));
			intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
			intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);

			// Register click event for the Background
			var piBackground = PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.UpdateCurrent);
			widgetView.SetOnClickPendingIntent(Resource.Id.widgetBackground, piBackground);
            Console.WriteLine("letobrojdebug end RegisterClicks");
        }
        /// <summary>
        /// This method is called when anything happens
        /// </summary>
        public override void OnReceive(Context context, Intent intent)
		{
            if (context == null)
            {
                Console.WriteLine("letobrojdebug OnReceive context null");
                return;
            }
            if (intent == null)
            {
                Console.WriteLine("letobrojdebug OnReceive intent null ");
                return;
            }
            Console.WriteLine("letobrojdebug OnReceive " + intent.Action);
            base.OnReceive(context, intent);
        }
    }
}
