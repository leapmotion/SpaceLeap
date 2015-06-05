﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CodeInstructionSet : InstructionSetBase {
    public const string REPLACEMENT_STRING = "#";
    public const short MESSAGE_ID = MsgType.Highest + 10;

    private string _instructionBase;
    private short _minNumber;
    private short _maxNumber;
    private byte _minDigits;

    public CodeInstructionSet(string instructionBase, int minNumber, int maxNumber, int minDigits) {
        _instructionBase = instructionBase;
        _minNumber = (short)minNumber;
        _maxNumber = (short)maxNumber;
        _minDigits = (byte)minDigits;
    }

    public override string getVariant(int variantIndex) {
        int number = _minNumber + variantIndex;
        string numberString = number.ToString().PadLeft(_minDigits, '0');
        return _instructionBase.Replace(REPLACEMENT_STRING, numberString);
    }

    public override int getVariantCount() {
        return _maxNumber - _minNumber + 1;
    }
}
