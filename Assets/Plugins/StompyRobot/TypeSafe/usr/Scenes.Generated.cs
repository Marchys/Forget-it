// ------------------------------------------------------------------------------
//  _______   _____ ___ ___   _   ___ ___ 
// |_   _\ \ / / _ \ __/ __| /_\ | __| __|
//   | |  \ V /|  _/ _|\__ \/ _ \| _|| _| 
//   |_|   |_| |_| |___|___/_/ \_\_| |___|
// 
// This file has been generated automatically by TypeSafe.
// Any changes to this file may be lost when it is regenerated.
// https://www.stompyrobot.uk/tools/typesafe
// 
// TypeSafe Version: 1.2.2-Unity5
// 
// ------------------------------------------------------------------------------



public sealed class SRScenes {
    
    private SRScenes() {
    }
    
    private const string _tsInternal = "1.2.2-Unity5";
    
    public static global::TypeSafe.Scene SectionA {
        get {
            return __all[0];
        }
    }
    
    public static global::TypeSafe.Scene Characters {
        get {
            return __all[1];
        }
    }
    
    public static global::TypeSafe.Scene Stage {
        get {
            return __all[2];
        }
    }
    
    public static global::TypeSafe.Scene Camera {
        get {
            return __all[3];
        }
    }
    
    public static global::TypeSafe.Scene Images {
        get {
            return __all[4];
        }
    }
    
    public static global::TypeSafe.Scene Localization {
        get {
            return __all[5];
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.Scene> __all = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.Scene>(new global::TypeSafe.Scene[] {
                new global::TypeSafe.Scene("Section-A", 0),
                new global::TypeSafe.Scene("Characters", 1),
                new global::TypeSafe.Scene("Stage", 2),
                new global::TypeSafe.Scene("Camera", 3),
                new global::TypeSafe.Scene("Images", 4),
                new global::TypeSafe.Scene("Localization", 5)});
    
    public static global::System.Collections.Generic.IList<global::TypeSafe.Scene> All {
        get {
            return __all;
        }
    }
}
