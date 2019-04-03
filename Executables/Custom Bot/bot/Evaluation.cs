using System;

// Token: 0x02000006 RID: 6
internal class Evaluation : Attribute
{
	// Token: 0x0600000E RID: 14 RVA: 0x00002072 File Offset: 0x00000272
	internal Evaluation(string string_0)
	{
		this.Warning = string_0;
	}

	// Token: 0x0400000B RID: 11
	internal readonly string Warning;
}
