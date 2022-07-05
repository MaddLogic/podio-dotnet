using System.Collections.Generic;
using PodioAPI.Models;
using PodioAPI.Models.Request;

namespace PodioAPI.Services
{
    public class ViewService
    {
        private readonly Podio _podio;

        public ViewService(Podio currentInstance)
        {
            _podio = currentInstance;
        }

        /// <summary>
        ///     Creates a new view on the given app.
        ///     <para>Podio API Reference: https://developers.podio.com/doc/views/create-view-27453 </para>
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="viewCreateRequest"></param>
        /// <returns></returns>
        public long CreateView(long appId, ViewCreateUpdateRequest request)
        {
            string url = string.Format("/view/app/{0}/", appId);
            dynamic response = _podio.Post<dynamic>(url, request);
            return (long) response["view_id"];
        }

        /// <summary>
        ///     Returns the definition for the given view. The view can be either a view id, a standard view or "last" for the last
        ///     view used.
        ///     <para>Podio API Reference: https://developers.podio.com/doc/views/get-view-27450 </para>
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="viewIdOrName"></param>
        /// <returns></returns>
        public View GetView(long appId, string viewIdOrName)
        {
            string url = string.Format("/view/app/{0}/{1}", appId, viewIdOrName);
            return _podio.Get<View>(url);
        }

        /// <summary>
        ///     Returns the views on the given app.
        ///     <para>Podio API Reference: https://developers.podio.com/doc/views/get-views-27460 </para>
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="includeStandardViews">True if standard views should be included, false otherwise. Default value: false</param>
        /// <returns></returns>
        public List<View> GetViews(long appId, bool includeStandardViews = false)
        {
            string url = string.Format("/view/app/{0}/", appId);
            var requestData = new Dictionary<string, string>
            {
                {"include_standard_views", includeStandardViews.ToString()}
            };
            return _podio.Get<List<View>>(url, requestData);
        }

        /// <summary>
        ///     Deletes the given view.
        ///     <para>Podio API Reference: https://developers.podio.com/doc/views/delete-view-27454 </para>
        /// </summary>
        /// <param name="viewId"></param>
        public void DeleteView(long viewId)
        {
            string url = string.Format("/view/{0}", viewId);
            _podio.Delete<dynamic>(url);
        }

        /// <summary>
        ///     Updates the last view for the active user.
        ///     <para>Podio API Reference: https://developers.podio.com/doc/views/update-last-view-5988251 </para>
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="request"></param>
        public void UpdateLastView(long appId, ViewCreateUpdateRequest request)
        {
            string url = string.Format("/view/app/{0}/last", appId);
            _podio.Put<dynamic>(url, request);
        }

        /// <summary>
        ///     Updates the given view.
        ///     <para>Podio API Reference: https://developers.podio.com/doc/views/update-view-20069949 </para>
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="request"></param>
        public void UpdateView(long viewId, ViewCreateUpdateRequest request)
        {
            string url = string.Format("/view/{0}", viewId);
            _podio.Put<dynamic>(url, request);
        }
    }
}