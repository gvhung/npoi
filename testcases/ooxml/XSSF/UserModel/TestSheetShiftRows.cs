/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for Additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */

using System;
using NUnit.Framework;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using TestCases.SS.UserModel;


namespace NPOI.XSSF.UserModel
{

    /**
     * Tests row Shifting capabilities.
     *
     * @author Shawn Laubach (slaubach at apache dot com)
     * @author Toshiaki Kamoshida (kamoshida.Toshiaki at future dot co dot jp)
     */
    [TestFixture]
    public class TestSheetShiftRows: BaseTestSheetShiftRows
    {
        public TestSheetShiftRows()
            : base(XSSFITestDataProvider.instance)
        {  }
        [Test]
        public void TestActiveCell()
        {
            base.TestActiveCell();
        }

        [Test]
        public void TestShiftRow()
        {
            base.TestShiftRow();
        }
        [Test]
        public void TestShiftRows()
        {
            base.TestShiftRows();
        }
        [Test]
        public void TestShiftRowBreaks()
        {
            base.TestShiftRowBreaks();
        }
        [Test]
        public void TestShiftWithComments()
        {
            base.TestShiftWithComments();
        }
        [Test]
        public void TestShiftWithFormulas()
        {
            base.TestShiftWithFormulas();
        }
        [Test]
        public void TestShiftWithMergedRegions()
        {
            base.TestShiftWithMergedRegions();
        }
        [Test]
        public void TestShiftWithNames()
        {
            base.TestShiftWithNames();
        }
    }
}
