<CODEGEN_FILENAME><StructureName>Tests.dbl</CODEGEN_FILENAME>
import System
import Microsoft.VisualStudio.TestTools.UnitTesting
import WcfServiceClient

namespace <NAMESPACE>

	{TestClass}
	public class <StructureName>Tests
		
		<PRIMARY_KEY>
		<SEGMENT_LOOP>
		private static mFirst<SegmentName>, <FIELD_SNTYPE>
		</SEGMENT_LOOP>
		</PRIMARY_KEY>
			
		<PRIMARY_KEY>
		<SEGMENT_LOOP>
		private static mBad<SegmentName>, <FIELD_SNTYPE>, <FIELD_SNDEFAULT>
		</SEGMENT_LOOP>
		</PRIMARY_KEY>
			
		{ClassInitialize}
		public static method ClassInitialize, void
			context, @TestContext
		proc
			data response = TestClient.Client.ReadAll<StructureName>s()
			if (response.Status == MethodStatus.Success && response.Result.Count > 0) then
			begin
				data first<StructureName> = response.Result[0]
				<PRIMARY_KEY>
				<SEGMENT_LOOP>
				mFirst<SegmentName> = first<StructureName>.<SegmentName>
				</SEGMENT_LOOP>
				</PRIMARY_KEY>
			end
			else
				throw new ApplicationException("<StructureName>Tests.ClassInitialize failed!")
        endmethod

		{TestMethod}
		public method ReadAll<StructureName>s, void
		proc
			data r = TestClient.Client.ReadAll<StructureName>s()
			Assert.IsTrue(r.Status == MethodStatus.Success && r.Result.Count > 0)
		endmethod

		{TestMethod}
		public method Read<StructureName>_Sucess, void
		proc
			data r = TestClient.Client.Read<StructureName>(<PRIMARY_KEY><SEGMENT_LOOP>mFirst<SegmentName><,></SEGMENT_LOOP></PRIMARY_KEY>)
			Assert.IsTrue(r.Status == MethodStatus.Success <PRIMARY_KEY><SEGMENT_LOOP> && r.Result.<SegmentName> == mFirst<SegmentName></SEGMENT_LOOP></PRIMARY_KEY>)
		endmethod

		{TestMethod}
		public method Read<StructureName>_Fail, void
		proc
			data r = TestClient.Client.Read<StructureName>(<PRIMARY_KEY><SEGMENT_LOOP>mBad<SegmentName><,></SEGMENT_LOOP></PRIMARY_KEY>)
			Assert.IsTrue(r.Status == MethodStatus.Fail)
		endmethod

		{TestMethod}
		public method Update<StructureName>, void
		proc
			data r1 = TestClient.Client.Read<StructureName>(<PRIMARY_KEY><SEGMENT_LOOP>mFirst<SegmentName><,></SEGMENT_LOOP></PRIMARY_KEY>)
			if (r1.Status == MethodStatus.Success) then
			begin
				data r2 = TestClient.Client.Update<StructureName>(r1.Result,r1.Grfa)
				Assert.IsTrue(r2.Status == MethodStatus.Success)
			end
			else
				Assert.Fail("Read<StructureName> failed in test Update<StructureName>")
		endmethod
		
		{TestMethod}
		public method Create<StructureName>, void
		proc
			data new<StructureName> = new <StructureName>()
			<PRIMARY_KEY>
			<SEGMENT_LOOP>
			new<StructureName>.<SegmentName> = mBad<SegmentName>
			</SEGMENT_LOOP>
			</PRIMARY_KEY>
			data response = TestClient.Client.Create<StructureName>(new<StructureName>)
			Assert.IsTrue(response.Status == MethodStatus.Success)
		endmethod
		
		{TestMethod}
		public method Delete<StructureName>, void
		proc
			data r1 = TestClient.Client.Read<StructureName>(<PRIMARY_KEY><SEGMENT_LOOP>mFirst<SegmentName><,></SEGMENT_LOOP></PRIMARY_KEY>)
			if (r1.Status == MethodStatus.Success) then
			begin
				data r2 = TestClient.Client.Delete<StructureName>(r1.Grfa)
				Assert.IsTrue(r2.Status == MethodStatus.Success)
			end
			else
				Assert.Fail("Read<StructureName> failed in test Delete<StructureName>")
		endmethod

	endclass

endnamespace
