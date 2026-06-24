using System;
using System.Collections.Generic;
using System.Text;

namespace FlareWall.Models;

public class Challenge
{
    public string FunctionName { get; set; } = "";

    public int A { get; set; }

    public int B { get; set; }

    public int ExpectedAnswer { get; set; }
}