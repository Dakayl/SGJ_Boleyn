public static class GlobalParameters {
    public static string ending { get; set; }

    private static Audio audio = null;

    public static Audio getAudio(){
        return audio;
    }

    public static Audio setAudio(Audio audioMgt){

        audio = audioMgt;
        return audio;
    }
}