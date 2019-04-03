using System;

// Token: 0x02000006 RID: 6
internal class Evaluation : Attribute
{
	// Token: 0x06000014 RID: 20 RVA: 0x00002098 File Offset: 0x00000298
	internal Evaluation(string string_0)
	{
		this.Warning = string_0;
	}

	// Token: 0x0400000A RID: 10
	internal readonly string Warning;
}
