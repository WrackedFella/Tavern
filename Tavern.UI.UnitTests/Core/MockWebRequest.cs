using Moq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Tavern.UI.UnitTests.Core
{
	public class MockWebRequest : IWebRequestCreate
	{
		public static WebRequest NextRequest { get; set; }

		public WebRequest Create(Uri uri)
		{
			return NextRequest;
		}

		public static HttpWebRequest CreateRequestWithResponseCode(HttpStatusCode httpStatusCode)
		{
			var response = new Mock<HttpWebResponse>(MockBehavior.Loose);
			response.Setup(c => c.StatusCode).Returns(httpStatusCode);

			var request = new Mock<HttpWebRequest>();
			request.Setup(s => s.GetResponse()).Returns(response.Object);
			NextRequest = request.Object;
			return request.Object;
		}

		// What the fuck guys.
		//public static HttpWebResponse CreateResponseWithResponseCodeWithHeaders(HttpStatusCode httpStatusCode)
		//{
		//    var response = new Mock<HttpWebResponse>(MockBehavior.Default);
		//    response.Setup(c => c.StatusCode).Returns(httpStatusCode);

		//    var request = new Mock<HttpWebRequest>();
		//    request.Setup(s => s.GetResponse()).Returns(response.Object);
		//    NextRequest = request.Object;

		//    response.Object.Headers = new WebHeaderCollection();
		//    response.Object.Headers.Add(HttpRequestHeader.Warning, "This is not a real response.");

		//    return request.Object;
		//}

		public static HttpWebRequest CreateRequestWithResponse(string responseContent)
		{
			var response = new Mock<HttpWebResponse>(MockBehavior.Loose);
			var responseStream = new MemoryStream(Encoding.UTF8.GetBytes(responseContent));
			response.Setup(c => c.StatusCode).Returns(HttpStatusCode.OK);
			response.Setup(c => c.GetResponseStream()).Returns(responseStream);

			var request = new Mock<HttpWebRequest>();
			request.Setup(s => s.GetResponse()).Returns(response.Object);
			NextRequest = request.Object;

			return request.Object;
		}
	}
}
