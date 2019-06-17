using System;

namespace TabletopStore.Models
{
    public class ErrorViewModel
    {
        //TODO:Error page
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}