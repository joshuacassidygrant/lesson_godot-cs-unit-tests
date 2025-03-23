public static class Examples {
    public static string SomeFunctionThatTakesTwoBooleans(bool a, bool b) {
        if (a) {
            if (b) {
                return "AB";
            } else {
                return "Just A";
            }
        }

        if (b) {
            return "It's B";
        }

        return "Neither";
    }

    public static string SomeFunctionThatTakesAnInteger(int value) {
        if (value >= 29) {
            return "Yeah!";
        }

        return "Nope!";
    }
    
}