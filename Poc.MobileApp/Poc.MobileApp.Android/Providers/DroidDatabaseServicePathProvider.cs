using Poc.MobileApp.Droid.Providers;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidDatabaseServicePathProvider))]
namespace Poc.MobileApp.Droid.Providers
{
	class DroidDatabaseServicePathProvider : IDatabaseServicePathProvider
	{
		public string GetPath()
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "applocaldb.db3");
		}
	}

}