﻿namespace CanHazFunny;

public static class Program
{
    public static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        new Jester(new JokeOutput(), new JokeService()).TellJoke();
    }
}
