﻿#region License
//   Copyright 2015 Brook Shi
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace AnimationToolkit.Animation
{
    public class FlipOutXAnimation : AnimationBase
    {
        public FlipOutXAnimation()
        {
            Duration = TimeSpan.FromMilliseconds(1200);
        }

        public override IAnimation PlayOn(UIElement target, Action continueWith)
        {
            var projection = (PlaneProjection)Utils.PrepareProjection(target, typeof(PlaneProjection));
            projection.CenterOfRotationY = 0.5;
            projection.RotationX = 0;
            target.Opacity = 1;

            var storyboard = PrepareStoryboard(continueWith);

            var opacityAnim = Utils.CreateAnimationWithValues(Duration.TotalMilliseconds, 0);
            AddAnimationToStoryboard(storyboard, target, opacityAnim, "Opacity");
            var rotateAnim = Utils.CreateAnimationWithValues(Duration.TotalMilliseconds, 90);
            AddAnimationToStoryboard(storyboard, projection, rotateAnim, "RotationX");

            storyboard.Begin();

            return this;
        }

    }
}
