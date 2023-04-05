using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class MobileRequirmentVerification
    {
        public int Id { get; set; }
        public int BeterryLife { get; set; }
        public bool IsCracked { get; set; }
        public bool IsScrached { get; set; }
        public bool IsScreenGood { get; set; }
        public bool IsScreenScreenTestPassed { get; set; }
        public string? AboutPhoneScreenShotURl { get; set; }
        public string? Ram { get; set; }
        public string? Storage { get; set; }
        public bool IsRamTestPassed { get; set;}
        public bool IsStorageTestPassed { get; set; }
        public string? CameraPhotoOneURL { get; set; }
        public string? CameraPhotoTwoURL { get; set; }
        public string? CameraPhotoThreeURL { get; set; }
        public bool IsScreenChanged { get; set; }
        public bool IsBetteryChanged { get; set; }
        public bool IsTouchTestPassed { get; set; }
    }
}
