
/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is1 distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */



namespace TestCases.HSSF.Record.Chart
{
    using System;
    using NPOI.HSSF.Record;

    using NUnit.Framework;

    /**
     * Tests the serialization and deserialization of the TextRecord
     * class works correctly.  Test data taken directly from a real
     * Excel file.
     *
     * @author Glen Stampoultzis (glens at apache.org)
     */
    [TestFixture]
    public class TestTextRecord
    {
        byte[] data = new byte[] {
        (byte)0x02,                                          // horiz align
        (byte)0x02,                                          // vert align
        (byte)0x01,(byte)0x00,                               // display mode
        (byte)0x00,(byte)0x00,(byte)0x00,(byte)0x00,         // rgb color
        (byte)0xD6,(byte)0xFF,(byte)0xFF,(byte)0xFF,         // x
        (byte)0xC4,(byte)0xFF,(byte)0xFF,(byte)0xFF,         // y
        (byte)0x00,(byte)0x00,(byte)0x00,(byte)0x00,         // width
        (byte)0x00,(byte)0x00,(byte)0x00,(byte)0x00,         // height
        (byte)0xB1,(byte)0x00,                               // options 1
        (byte)0x4D,(byte)0x00,                               // index of color value
        (byte)0x50,(byte)0x2B,                               // options 2       -- strange upper bits supposed to be 0'd
        (byte)0x00,(byte)0x00                                // text rotation
        };

        public TestTextRecord()
        {

        }
        [Test]
        public void TestLoad()
        {

            TextRecord record = new TextRecord(TestcaseRecordInputStream.Create((short)0x1025, data));
            Assert.AreEqual(TextRecord.HORIZONTAL_ALIGNMENT_CENTER, record.HorizontalAlignment);
            Assert.AreEqual(TextRecord.VERTICAL_ALIGNMENT_CENTER, record.VerticalAlignment);
            Assert.AreEqual(TextRecord.DISPLAY_MODE_TRANSPARENT, record.DisplayMode);
            Assert.AreEqual(0, record.RgbColor);
            Assert.AreEqual(-42, record.X);
            Assert.AreEqual(-60, record.Y);
            Assert.AreEqual(0, record.Width);
            Assert.AreEqual(0, record.Height);
            Assert.AreEqual(177, record.Options1);
            Assert.AreEqual(true, record.IsAutoColor);
            Assert.AreEqual(false, record.ShowKey);
            Assert.AreEqual(false, record.ShowValue);
            Assert.AreEqual(false, record.IsVertical);
            Assert.AreEqual(true, record.IsAutoGeneratedText);
            Assert.AreEqual(true, record.IsGenerated);
            Assert.AreEqual(false, record.IsAutoLabelDeleted);
            Assert.AreEqual(true, record.IsAutoBackground);
            Assert.AreEqual(TextRecord.ROTATION_NONE, record.Rotation);
            Assert.AreEqual(false, record.ShowCategoryLabelAsPercentage);
            Assert.AreEqual(false, record.ShowValueAsPercentage);
            Assert.AreEqual(false, record.ShowBubbleSizes);
            Assert.AreEqual(false, record.ShowLabel);
            Assert.AreEqual(77, record.IndexOfColorValue);
            Assert.AreEqual(11088, record.Options2);
            Assert.AreEqual(0, record.DataLabelPlacement);
            Assert.AreEqual(0, record.TextRotation);


            Assert.AreEqual(36, record.RecordSize);
        }
        [Test]
        public void TestStore()
        {
            TextRecord record = new TextRecord();
            record.HorizontalAlignment=( TextRecord.HORIZONTAL_ALIGNMENT_CENTER );
            record.VerticalAlignment=( TextRecord.VERTICAL_ALIGNMENT_CENTER );
            record.DisplayMode=( TextRecord.DISPLAY_MODE_TRANSPARENT );
            record.RgbColor=( 0 );
            record.X=( -42 );
            record.Y=( -60 );
            record.Width=( 0 );
            record.Height=( 0 );
            record.IsAutoColor=( true );
            record.ShowKey=( false );
            record.ShowValue=( false );
            record.IsVertical=( false );
            record.IsAutoGeneratedText=( true );
            record.IsGenerated=( true );
            record.IsAutoLabelDeleted=( false );
            record.IsAutoBackground=( true );
            record.Rotation=(  TextRecord.ROTATION_NONE );
            record.ShowCategoryLabelAsPercentage=( false );
            record.ShowValueAsPercentage=( false );
            record.ShowBubbleSizes=( false );
            record.ShowLabel=( false );
            record.IndexOfColorValue=(short)77 ;
            record.Options2=(short)0x2b50 ;
    //        record.DataLabelPlacement=((short)0x2b50 );
            record.TextRotation=(short)0 ;


            byte [] recordBytes = record.Serialize();
            Assert.AreEqual(recordBytes.Length - 4, data.Length);
            for (int i = 0; i < data.Length; i++)
                Assert.AreEqual(data[i], recordBytes[i+4],"At offset " + i);
            }
    }
}