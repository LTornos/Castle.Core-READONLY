namespace SampleSite.Controllers
{
	using System;

	using Castle.CastleOnRails.Framework;

	[Filter(ExecuteEnum.After, typeof(FooterLinkFilter))]
	[Layout("default")]
	public class AbstractApplicationController : Controller
	{
	}

	[Filter(ExecuteEnum.After, typeof(FooterLinkFilter))]
	[Layout("defaultajax")]
	public class AbstractAjaxApplicationController : SmartDispatcherController
	{
	}
}
