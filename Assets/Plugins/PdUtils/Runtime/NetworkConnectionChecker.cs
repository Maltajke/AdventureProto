using System;
using System.Net;
using UnityEngine.Networking;

namespace PdUtils
{
	public static class NetworkConnectionChecker
	{
		public static void Check(Action success, Action fail)
		{
			var request = UnityWebRequest.Get("https://api.ipify.org");
			var async = request.SendWebRequest();
			async.completed += operation =>
			{
				var someError = request.isNetworkError || request.isHttpError ||
				                request.responseCode != (long) HttpStatusCode.OK;
				if (someError)
				{
					fail?.Invoke();
				}
				else
				{
					success?.Invoke();
				}
			};
		}
	}
}