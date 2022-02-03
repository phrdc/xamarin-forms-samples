using Xamarin.Forms;

namespace LoginNavigation
{
	public class App : Application
	{
		public static bool IsUserLoggedIn { get; set; }

		public App ()
		{
			if (!IsUserLoggedIn) {
				MainPage = new NavigationPage (new LoginPage ());
			} else {
				MainPage = new NavigationPage (new LoginNavigation.MainPage ());
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public bool PromptToConfirmExit
        {
            get
            {
                bool promptToConfirmExit = false;
                if (MainPage is ContentPage)
                {
                    promptToConfirmExit = true;
                }
                else if (MainPage is Xamarin.Forms.MasterDetailPage masterDetailPage
                    && masterDetailPage.Detail is NavigationPage detailNavigationPage)
                {
                    promptToConfirmExit = detailNavigationPage.Navigation.NavigationStack.Count <= 1;
                }
                else if (MainPage is NavigationPage mainPage)
                {
                    if (mainPage.CurrentPage is TabbedPage tabbedPage
                        && tabbedPage.CurrentPage is NavigationPage navigationPage)
                    {
                        promptToConfirmExit = navigationPage.Navigation.NavigationStack.Count <= 1;
                    }
                    else
                    {
                        promptToConfirmExit = mainPage.Navigation.NavigationStack.Count <= 1;
                    }
                }
                else if (MainPage is TabbedPage tabbedPage
                    && tabbedPage.CurrentPage is NavigationPage navigationPage)
                {
                    promptToConfirmExit = navigationPage.Navigation.NavigationStack.Count <= 1;
                }
                return promptToConfirmExit;
            }
        }


    }
}

