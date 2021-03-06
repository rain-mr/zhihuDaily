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
using Windows.UI.Xaml.Media.Animation;

namespace AnimationToolkit
{
    public abstract class AnimationBase : IAnimation
    {
        protected TimeSpan? Delay { get; set; }

        protected TimeSpan Duration { get; set; }

        protected RepeatBehavior RepeatBehavior { get; set; } = new RepeatBehavior(1);

        protected Storyboard Storyboard { get; set; } = new Storyboard();

        public IAnimation ContinueWith(Type type)
        {
            throw new NotImplementedException();
        }

        public IAnimation PlayOn(UIElement target)
        {
            return PlayOn(target, null);
        }

        public abstract IAnimation PlayOn(UIElement target, Action ContinueWith);

        public virtual IAnimation SetDelay(TimeSpan delay)
        {
            Delay = delay;
            return this;
        }

        public IAnimation SetDuration(TimeSpan duration)
        {
            Duration = duration;
            return this;
        }

        public IAnimation SetRepeatBehavior(RepeatBehavior repeatBehavior)
        {
            RepeatBehavior = repeatBehavior;
            return this;
        }

        protected Storyboard PrepareStoryboard(Action continueWith)
        {
            Storyboard.Completed += (s, e) =>
            {
                if (continueWith != null)
                    continueWith();
            };

            Storyboard.BeginTime = Delay;
            Storyboard.RepeatBehavior = RepeatBehavior;

            return Storyboard;
        }

        public virtual void Stop()
        {
            Storyboard.Stop();
        }

        protected void AddAnimationToStoryboard(Storyboard storyboard, DependencyObject target, Timeline anim, string property)
        {
            storyboard.Children.Add(anim);

            Storyboard.SetTarget(anim, target);
            Storyboard.SetTargetProperty(anim, property);
        }
    }
}
