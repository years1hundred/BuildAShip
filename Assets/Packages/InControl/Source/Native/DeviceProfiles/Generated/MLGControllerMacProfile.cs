namespace InControl.NativeProfile
{
	// @cond nodoc
	[AutoDiscover, Preserve]
	public class MLGControllerMacProfile : Xbox360DriverMacProfile
	{
		public MLGControllerMacProfile()
		{
			Name = "MLG Controller";
			Meta = "MLG Controller on Mac";

			Matchers = new[]
			{
				new NativeInputDeviceMatcher
				{
					VendorID = 0x1bad,
					ProductID = 0xf023,
				},
			};
		}
	}

	// @endcond
}


