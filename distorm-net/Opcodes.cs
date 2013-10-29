﻿ 
 
// This file was auto generated from the distrom opcodes.h file
// on 2013-10-29 13:40:47.655

namespace diStorm 
{ 
  public enum Opcode : ushort {
    UNDEFINED = 0,
    AAA = 66,
    AAD = 389,
    AAM = 384,
    AAS = 76,
    ADC = 31,
    ADD = 11,
    ADDPD = 3110,
    ADDPS = 3103,
    ADDSD = 3124,
    ADDSS = 3117,
    ADDSUBPD = 6394,
    ADDSUBPS = 6404,
    AESDEC = 9209,
    AESDECLAST = 9226,
    AESENC = 9167,
    AESENCLAST = 9184,
    AESIMC = 9150,
    AESKEYGENASSIST = 9795,
    AND = 41,
    ANDNPD = 3021,
    ANDNPS = 3013,
    ANDPD = 2990,
    ANDPS = 2983,
    ARPL = 111,
    BLENDPD = 9372,
    BLENDPS = 9353,
    BLENDVPD = 7619,
    BLENDVPS = 7609,
    BOUND = 104,
    BSF = 4346,
    BSR = 4358,
    BSWAP = 960,
    BT = 872,
    BTC = 934,
    BTR = 912,
    BTS = 887,
    CALL = 456,
    CALL_FAR = 260,
    CBW = 228,
    CDQ = 250,
    CDQE = 239,
    CLC = 492,
    CLD = 512,
    CLFLUSH = 4329,
    CLGI = 1833,
    CLI = 502,
    CLTS = 541,
    CMC = 487,
    CMOVA = 694,
    CMOVAE = 663,
    CMOVB = 656,
    CMOVBE = 686,
    CMOVG = 754,
    CMOVGE = 738,
    CMOVL = 731,
    CMOVLE = 746,
    CMOVNO = 648,
    CMOVNP = 723,
    CMOVNS = 708,
    CMOVNZ = 678,
    CMOVO = 641,
    CMOVP = 716,
    CMOVS = 701,
    CMOVZ = 671,
    CMP = 71,
    CMPEQPD = 4449,
    CMPEQPS = 4370,
    CMPEQSD = 4607,
    CMPEQSS = 4528,
    CMPLEPD = 4467,
    CMPLEPS = 4388,
    CMPLESD = 4625,
    CMPLESS = 4546,
    CMPLTPD = 4458,
    CMPLTPS = 4379,
    CMPLTSD = 4616,
    CMPLTSS = 4537,
    CMPNEQPD = 4488,
    CMPNEQPS = 4409,
    CMPNEQSD = 4646,
    CMPNEQSS = 4567,
    CMPNLEPD = 4508,
    CMPNLEPS = 4429,
    CMPNLESD = 4666,
    CMPNLESS = 4587,
    CMPNLTPD = 4498,
    CMPNLTPS = 4419,
    CMPNLTSD = 4656,
    CMPNLTSS = 4577,
    CMPORDPD = 4518,
    CMPORDPS = 4439,
    CMPORDSD = 4676,
    CMPORDSS = 4597,
    CMPS = 301,
    CMPUNORDPD = 4476,
    CMPUNORDPS = 4397,
    CMPUNORDSD = 4634,
    CMPUNORDSS = 4555,
    CMPXCHG = 898,
    CMPXCHG16B = 6373,
    CMPXCHG8B = 6362,
    COMISD = 2779,
    COMISS = 2771,
    CPUID = 865,
    CQO = 255,
    CRC32 = 9258,
    CVTDQ2PD = 6787,
    CVTDQ2PS = 3307,
    CVTPD2DQ = 6797,
    CVTPD2PI = 2681,
    CVTPD2PS = 3233,
    CVTPH2PS = 4161,
    CVTPI2PD = 2495,
    CVTPI2PS = 2485,
    CVTPS2DQ = 3317,
    CVTPS2PD = 3223,
    CVTPS2PH = 4171,
    CVTPS2PI = 2671,
    CVTSD2SI = 2701,
    CVTSD2SS = 3253,
    CVTSI2SD = 2515,
    CVTSI2SS = 2505,
    CVTSS2SD = 3243,
    CVTSS2SI = 2691,
    CVTTPD2DQ = 6776,
    CVTTPD2PI = 2614,
    CVTTPS2DQ = 3327,
    CVTTPS2PI = 2603,
    CVTTSD2SI = 2636,
    CVTTSS2SI = 2625,
    CWD = 245,
    CWDE = 233,
    DAA = 46,
    DAS = 56,
    DEC = 86,
    DIV = 1630,
    DIVPD = 3499,
    DIVPS = 3492,
    DIVSD = 3513,
    DIVSS = 3506,
    DPPD = 9615,
    DPPS = 9602,
    EMMS = 4100,
    ENTER = 340,
    EXTRACTPS = 9480,
    EXTRQ = 4136,
    F2XM1 = 1176,
    FABS = 1107,
    FADD = 1007,
    FADDP = 1533,
    FBLD = 1585,
    FBSTP = 1591,
    FCHS = 1101,
    FCLEX = 7289,
    FCMOVB = 1360,
    FCMOVBE = 1376,
    FCMOVE = 1368,
    FCMOVNB = 1429,
    FCMOVNBE = 1447,
    FCMOVNE = 1438,
    FCMOVNU = 1457,
    FCMOVU = 1385,
    FCOM = 1019,
    FCOMI = 1496,
    FCOMIP = 1607,
    FCOMP = 1025,
    FCOMPP = 1547,
    FCOS = 1295,
    FDECSTP = 1222,
    FDIV = 1045,
    FDIVP = 1578,
    FDIVR = 1051,
    FDIVRP = 1570,
    FEDISI = 1472,
    FEMMS = 574,
    FENI = 1466,
    FFREE = 1511,
    FIADD = 1301,
    FICOM = 1315,
    FICOMP = 1322,
    FIDIV = 1345,
    FIDIVR = 1352,
    FILD = 1402,
    FIMUL = 1308,
    FINCSTP = 1231,
    FINIT = 7304,
    FIST = 1416,
    FISTP = 1422,
    FISTTP = 1408,
    FISUB = 1330,
    FISUBR = 1337,
    FLD = 1058,
    FLD1 = 1125,
    FLDCW = 1082,
    FLDENV = 1074,
    FLDL2E = 1139,
    FLDL2T = 1131,
    FLDLG2 = 1154,
    FLDLN2 = 1162,
    FLDPI = 1147,
    FLDZ = 1170,
    FMUL = 1013,
    FMULP = 1540,
    FNCLEX = 7281,
    FNINIT = 7296,
    FNOP = 1095,
    FNSAVE = 7311,
    FNSTCW = 7266,
    FNSTENV = 7249,
    FNSTSW = 7326,
    FPATAN = 1197,
    FPREM = 1240,
    FPREM1 = 1214,
    FPTAN = 1190,
    FRNDINT = 1272,
    FRSTOR = 1503,
    FSAVE = 7319,
    FSCALE = 1281,
    FSETPM = 1480,
    FSIN = 1289,
    FSINCOS = 1263,
    FSQRT = 1256,
    FST = 1063,
    FSTCW = 7274,
    FSTENV = 7258,
    FSTP = 1068,
    FSTSW = 7334,
    FSUB = 1032,
    FSUBP = 1563,
    FSUBR = 1038,
    FSUBRP = 1555,
    FTST = 1113,
    FUCOM = 1518,
    FUCOMI = 1488,
    FUCOMIP = 1598,
    FUCOMP = 1525,
    FUCOMPP = 1393,
    FXAM = 1119,
    FXCH = 1089,
    FXRSTOR = 9892,
    FXRSTOR64 = 9901,
    FXSAVE = 9864,
    FXSAVE64 = 9872,
    FXTRACT = 1205,
    FYL2X = 1183,
    FYL2XP1 = 1247,
    GETSEC = 633,
    HADDPD = 4181,
    HADDPS = 4189,
    HLT = 482,
    HSUBPD = 4215,
    HSUBPS = 4223,
    IDIV = 1635,
    IMUL = 117,
    IN = 447,
    INC = 81,
    INS = 123,
    INSERTPS = 9547,
    INSERTQ = 4143,
    INT = 367,
    INT_3 = 360,
    INT1 = 476,
    INTO = 372,
    INVD = 555,
    INVEPT = 8284,
    INVLPG = 1711,
    INVLPGA = 1847,
    INVPCID = 8301,
    INVVPID = 8292,
    IRET = 378,
    JA = 166,
    JAE = 147,
    JB = 143,
    JBE = 161,
    JCXZ = 427,
    JECXZ = 433,
    JG = 202,
    JGE = 192,
    JL = 188,
    JLE = 197,
    JMP = 462,
    JMP_FAR = 467,
    JNO = 138,
    JNP = 183,
    JNS = 174,
    JNZ = 156,
    JO = 134,
    JP = 179,
    JRCXZ = 440,
    JS = 170,
    JZ = 152,
    LAHF = 289,
    LAR = 522,
    LDDQU = 6994,
    LDMXCSR = 9922,
    LDS = 335,
    LEA = 223,
    LEAVE = 347,
    LES = 330,
    LFENCE = 4265,
    LFS = 917,
    LGDT = 1687,
    LGS = 922,
    LIDT = 1693,
    LLDT = 1652,
    LMSW = 1705,
    LODS = 313,
    LOOP = 421,
    LOOPNZ = 406,
    LOOPZ = 414,
    LSL = 527,
    LSS = 907,
    LTR = 1658,
    LZCNT = 4363,
    MASKMOVDQU = 7119,
    MASKMOVQ = 7109,
    MAXPD = 3559,
    MAXPS = 3552,
    MAXSD = 3573,
    MAXSS = 3566,
    MFENCE = 4291,
    MINPD = 3439,
    MINPS = 3432,
    MINSD = 3453,
    MINSS = 3446,
    MONITOR = 1755,
    MOV = 218,
    MOVAPD = 2459,
    MOVAPS = 2451,
    MOVBE = 9251,
    MOVD = 3920,
    MOVDDUP = 2186,
    MOVDQ2Q = 6522,
    MOVDQA = 3946,
    MOVDQU = 3954,
    MOVHLPS = 2151,
    MOVHPD = 2345,
    MOVHPS = 2337,
    MOVLHPS = 2328,
    MOVLPD = 2168,
    MOVLPS = 2160,
    MOVMSKPD = 2815,
    MOVMSKPS = 2805,
    MOVNTDQ = 6849,
    MOVNTDQA = 7895,
    MOVNTI = 952,
    MOVNTPD = 2556,
    MOVNTPS = 2547,
    MOVNTQ = 6841,
    MOVNTSD = 2574,
    MOVNTSS = 2565,
    MOVQ = 3926,
    MOVQ2DQ = 6513,
    MOVS = 295,
    MOVSD = 2110,
    MOVSHDUP = 2353,
    MOVSLDUP = 2176,
    MOVSS = 2103,
    MOVSX = 939,
    MOVSXD = 10013,
    MOVUPD = 2095,
    MOVUPS = 2087,
    MOVZX = 927,
    MPSADBW = 9628,
    MUL = 1625,
    MULPD = 3170,
    MULPS = 3163,
    MULSD = 3184,
    MULSS = 3177,
    MWAIT = 1764,
    NEG = 1620,
    NOP = 581,
    NOT = 1615,
    OR = 27,
    ORPD = 3053,
    ORPS = 3047,
    OUT = 451,
    OUTS = 128,
    PABSB = 7688,
    PABSD = 7718,
    PABSW = 7703,
    PACKSSDW = 3849,
    PACKSSWB = 3681,
    PACKUSDW = 7916,
    PACKUSWB = 3759,
    PADDB = 7204,
    PADDD = 7234,
    PADDQ = 6481,
    PADDSB = 6930,
    PADDSW = 6947,
    PADDUSB = 6620,
    PADDUSW = 6639,
    PADDW = 7219,
    PALIGNR = 9410,
    PAND = 6607,
    PANDN = 6665,
    PAUSE = 10021,
    PAVGB = 6680,
    PAVGUSB = 2078,
    PAVGW = 6725,
    PBLENDVB = 7599,
    PBLENDW = 9391,
    PCLMULQDQ = 9647,
    PCMPEQB = 4043,
    PCMPEQD = 4081,
    PCMPEQQ = 7876,
    PCMPEQW = 4062,
    PCMPESTRI = 9726,
    PCMPESTRM = 9703,
    PCMPGTB = 3702,
    PCMPGTD = 3740,
    PCMPGTQ = 8087,
    PCMPGTW = 3721,
    PCMPISTRI = 9772,
    PCMPISTRM = 9749,
    PEXTRB = 9429,
    PEXTRD = 9446,
    PEXTRQ = 9454,
    PEXTRW = 6311,
    PF2ID = 1914,
    PF2IW = 1907,
    PFACC = 2028,
    PFADD = 1977,
    PFCMPEQ = 2035,
    PFCMPGE = 1938,
    PFCMPGT = 1984,
    PFMAX = 1993,
    PFMIN = 1947,
    PFMUL = 2044,
    PFNACC = 1921,
    PFPNACC = 1929,
    PFRCP = 1954,
    PFRCPIT1 = 2000,
    PFRCPIT2 = 2051,
    PFRSQIT1 = 2010,
    PFRSQRT = 1961,
    PFSUB = 1970,
    PFSUBR = 2020,
    PHADDD = 7375,
    PHADDSW = 7392,
    PHADDW = 7358,
    PHMINPOSUW = 8259,
    PHSUBD = 7451,
    PHSUBSW = 7468,
    PHSUBW = 7434,
    PI2FD = 1900,
    PI2FW = 1893,
    PINSRB = 9530,
    PINSRD = 9568,
    PINSRQ = 9576,
    PINSRW = 6294,
    PMADDUBSW = 7411,
    PMADDWD = 7073,
    PMAXSB = 8174,
    PMAXSD = 8191,
    PMAXSW = 6964,
    PMAXUB = 6648,
    PMAXUD = 8225,
    PMAXUW = 8208,
    PMINSB = 8106,
    PMINSD = 8123,
    PMINSW = 6902,
    PMINUB = 6590,
    PMINUD = 8157,
    PMINUW = 8140,
    PMOVMSKB = 6531,
    PMOVSXBD = 7754,
    PMOVSXBQ = 7775,
    PMOVSXBW = 7733,
    PMOVSXDQ = 7838,
    PMOVSXWD = 7796,
    PMOVSXWQ = 7817,
    PMOVZXBD = 7982,
    PMOVZXBQ = 8003,
    PMOVZXBW = 7961,
    PMOVZXDQ = 8066,
    PMOVZXWD = 8024,
    PMOVZXWQ = 8045,
    PMULDQ = 7859,
    PMULHRSW = 7538,
    PMULHRW = 2061,
    PMULHUW = 6740,
    PMULHW = 6759,
    PMULLD = 8242,
    PMULLW = 6496,
    PMULUDQ = 7054,
    POP = 22,
    POPA = 98,
    POPCNT = 4338,
    POPF = 277,
    POR = 6919,
    PREFETCH = 1872,
    PREFETCHNTA = 2402,
    PREFETCHT0 = 2415,
    PREFETCHT1 = 2427,
    PREFETCHT2 = 2439,
    PREFETCHW = 1882,
    PSADBW = 7092,
    PSHUFB = 7341,
    PSHUFD = 3988,
    PSHUFHW = 3996,
    PSHUFLW = 4005,
    PSHUFW = 3980,
    PSIGNB = 7487,
    PSIGND = 7521,
    PSIGNW = 7504,
    PSLLD = 7024,
    PSLLDQ = 9847,
    PSLLQ = 7039,
    PSLLW = 7009,
    PSRAD = 6710,
    PSRAW = 6695,
    PSRLD = 6451,
    PSRLDQ = 9830,
    PSRLQ = 6466,
    PSRLW = 6436,
    PSUBB = 7144,
    PSUBD = 7174,
    PSUBQ = 7189,
    PSUBSB = 6868,
    PSUBSW = 6885,
    PSUBUSB = 6552,
    PSUBUSW = 6571,
    PSUBW = 7159,
    PSWAPD = 2070,
    PTEST = 7629,
    PUNPCKHBW = 3780,
    PUNPCKHDQ = 3826,
    PUNPCKHQDQ = 3895,
    PUNPCKHWD = 3803,
    PUNPCKLBW = 3612,
    PUNPCKLDQ = 3658,
    PUNPCKLQDQ = 3870,
    PUNPCKLWD = 3635,
    PUSH = 16,
    PUSHA = 91,
    PUSHF = 270,
    PXOR = 6981,
    RCL = 977,
    RCPPS = 2953,
    RCPSS = 2960,
    RCR = 982,
    RDFSBASE = 9882,
    RDGSBASE = 9912,
    RDMSR = 600,
    RDPMC = 607,
    RDRAND = 9980,
    RDTSC = 593,
    RDTSCP = 1864,
    RET = 325,
    RETF = 354,
    ROL = 967,
    ROR = 972,
    ROUNDPD = 9296,
    ROUNDPS = 9277,
    ROUNDSD = 9334,
    ROUNDSS = 9315,
    RSM = 882,
    RSQRTPS = 2915,
    RSQRTSS = 2924,
    SAHF = 283,
    SAL = 997,
    SALC = 394,
    SAR = 1002,
    SBB = 36,
    SCAS = 319,
    SETA = 807,
    SETAE = 780,
    SETB = 774,
    SETBE = 800,
    SETG = 859,
    SETGE = 845,
    SETL = 839,
    SETLE = 852,
    SETNO = 767,
    SETNP = 832,
    SETNS = 819,
    SETNZ = 793,
    SETO = 761,
    SETP = 826,
    SETS = 813,
    SETZ = 787,
    SFENCE = 4321,
    SGDT = 1675,
    SHL = 987,
    SHLD = 876,
    SHR = 992,
    SHRD = 892,
    SHUFPD = 6336,
    SHUFPS = 6328,
    SIDT = 1681,
    SKINIT = 1839,
    SLDT = 1641,
    SMSW = 1699,
    SQRTPD = 2855,
    SQRTPS = 2847,
    SQRTSD = 2871,
    SQRTSS = 2863,
    STC = 497,
    STD = 517,
    STGI = 1827,
    STI = 507,
    STMXCSR = 9951,
    STOS = 307,
    STR = 1647,
    SUB = 51,
    SUBPD = 3379,
    SUBPS = 3372,
    SUBSD = 3393,
    SUBSS = 3386,
    SWAPGS = 1856,
    SYSCALL = 532,
    SYSENTER = 614,
    SYSEXIT = 624,
    SYSRET = 547,
    TEST = 206,
    TZCNT = 4351,
    UCOMISD = 2742,
    UCOMISS = 2733,
    UD2 = 569,
    UNPCKHPD = 2296,
    UNPCKHPS = 2286,
    UNPCKLPD = 2254,
    UNPCKLPS = 2244,
    VADDPD = 3139,
    VADDPS = 3131,
    VADDSD = 3155,
    VADDSS = 3147,
    VADDSUBPD = 6414,
    VADDSUBPS = 6425,
    VAESDEC = 9217,
    VAESDECLAST = 9238,
    VAESENC = 9175,
    VAESENCLAST = 9196,
    VAESIMC = 9158,
    VAESKEYGENASSIST = 9812,
    VANDNPD = 3038,
    VANDNPS = 3029,
    VANDPD = 3005,
    VANDPS = 2997,
    VBLENDPD = 9381,
    VBLENDPS = 9362,
    VBLENDVPD = 9681,
    VBLENDVPS = 9670,
    VBROADCASTF128 = 7672,
    VBROADCASTSD = 7658,
    VBROADCASTSS = 7644,
    VCMPEQPD = 5088,
    VCMPEQPS = 4686,
    VCMPEQSD = 5892,
    VCMPEQSS = 5490,
    VCMPEQ_OSPD = 5269,
    VCMPEQ_OSPS = 4867,
    VCMPEQ_OSSD = 6073,
    VCMPEQ_OSSS = 5671,
    VCMPEQ_UQPD = 5175,
    VCMPEQ_UQPS = 4773,
    VCMPEQ_UQSD = 5979,
    VCMPEQ_UQSS = 5577,
    VCMPEQ_USPD = 5378,
    VCMPEQ_USPS = 4976,
    VCMPEQ_USSD = 6182,
    VCMPEQ_USSS = 5780,
    VCMPFALSEPD = 5210,
    VCMPFALSEPS = 4808,
    VCMPFALSESD = 6014,
    VCMPFALSESS = 5612,
    VCMPFALSE_OSPD = 5419,
    VCMPFALSE_OSPS = 5017,
    VCMPFALSE_OSSD = 6223,
    VCMPFALSE_OSSS = 5821,
    VCMPGEPD = 5237,
    VCMPGEPS = 4835,
    VCMPGESD = 6041,
    VCMPGESS = 5639,
    VCMPGE_OQPD = 5449,
    VCMPGE_OQPS = 5047,
    VCMPGE_OQSD = 6253,
    VCMPGE_OQSS = 5851,
    VCMPGTPD = 5247,
    VCMPGTPS = 4845,
    VCMPGTSD = 6051,
    VCMPGTSS = 5649,
    VCMPGT_OQPD = 5462,
    VCMPGT_OQPS = 5060,
    VCMPGT_OQSD = 6266,
    VCMPGT_OQSS = 5864,
    VCMPLEPD = 5108,
    VCMPLEPS = 4706,
    VCMPLESD = 5912,
    VCMPLESS = 5510,
    VCMPLE_OQPD = 5295,
    VCMPLE_OQPS = 4893,
    VCMPLE_OQSD = 6099,
    VCMPLE_OQSS = 5697,
    VCMPLTPD = 5098,
    VCMPLTPS = 4696,
    VCMPLTSD = 5902,
    VCMPLTSS = 5500,
    VCMPLT_OQPD = 5282,
    VCMPLT_OQPS = 4880,
    VCMPLT_OQSD = 6086,
    VCMPLT_OQSS = 5684,
    VCMPNEQPD = 5131,
    VCMPNEQPS = 4729,
    VCMPNEQSD = 5935,
    VCMPNEQSS = 5533,
    VCMPNEQ_OQPD = 5223,
    VCMPNEQ_OQPS = 4821,
    VCMPNEQ_OQSD = 6027,
    VCMPNEQ_OQSS = 5625,
    VCMPNEQ_OSPD = 5435,
    VCMPNEQ_OSPS = 5033,
    VCMPNEQ_OSSD = 6239,
    VCMPNEQ_OSSS = 5837,
    VCMPNEQ_USPD = 5323,
    VCMPNEQ_USPS = 4921,
    VCMPNEQ_USSD = 6127,
    VCMPNEQ_USSS = 5725,
    VCMPNGEPD = 5188,
    VCMPNGEPS = 4786,
    VCMPNGESD = 5992,
    VCMPNGESS = 5590,
    VCMPNGE_UQPD = 5391,
    VCMPNGE_UQPS = 4989,
    VCMPNGE_UQSD = 6195,
    VCMPNGE_UQSS = 5793,
    VCMPNGTPD = 5199,
    VCMPNGTPS = 4797,
    VCMPNGTSD = 6003,
    VCMPNGTSS = 5601,
    VCMPNGT_UQPD = 5405,
    VCMPNGT_UQPS = 5003,
    VCMPNGT_UQSD = 6209,
    VCMPNGT_UQSS = 5807,
    VCMPNLEPD = 5153,
    VCMPNLEPS = 4751,
    VCMPNLESD = 5957,
    VCMPNLESS = 5555,
    VCMPNLE_UQPD = 5351,
    VCMPNLE_UQPS = 4949,
    VCMPNLE_UQSD = 6155,
    VCMPNLE_UQSS = 5753,
    VCMPNLTPD = 5142,
    VCMPNLTPS = 4740,
    VCMPNLTSD = 5946,
    VCMPNLTSS = 5544,
    VCMPNLT_UQPD = 5337,
    VCMPNLT_UQPS = 4935,
    VCMPNLT_UQSD = 6141,
    VCMPNLT_UQSS = 5739,
    VCMPORDPD = 5164,
    VCMPORDPS = 4762,
    VCMPORDSD = 5968,
    VCMPORDSS = 5566,
    VCMPORD_SPD = 5365,
    VCMPORD_SPS = 4963,
    VCMPORD_SSD = 6169,
    VCMPORD_SSS = 5767,
    VCMPTRUEPD = 5257,
    VCMPTRUEPS = 4855,
    VCMPTRUESD = 6061,
    VCMPTRUESS = 5659,
    VCMPTRUE_USPD = 5475,
    VCMPTRUE_USPS = 5073,
    VCMPTRUE_USSD = 6279,
    VCMPTRUE_USSS = 5877,
    VCMPUNORDPD = 5118,
    VCMPUNORDPS = 4716,
    VCMPUNORDSD = 5922,
    VCMPUNORDSS = 5520,
    VCMPUNORD_SPD = 5308,
    VCMPUNORD_SPS = 4906,
    VCMPUNORD_SSD = 6112,
    VCMPUNORD_SSS = 5710,
    VCOMISD = 2796,
    VCOMISS = 2787,
    VCVTDQ2PD = 6819,
    VCVTDQ2PS = 3338,
    VCVTPD2DQ = 6830,
    VCVTPD2PS = 3274,
    VCVTPS2DQ = 3349,
    VCVTPS2PD = 3263,
    VCVTSD2SI = 2722,
    VCVTSD2SS = 3296,
    VCVTSI2SD = 2536,
    VCVTSI2SS = 2525,
    VCVTSS2SD = 3285,
    VCVTSS2SI = 2711,
    VCVTTPD2DQ = 6807,
    VCVTTPS2DQ = 3360,
    VCVTTSD2SI = 2659,
    VCVTTSS2SI = 2647,
    VDIVPD = 3528,
    VDIVPS = 3520,
    VDIVSD = 3544,
    VDIVSS = 3536,
    VDPPD = 9621,
    VDPPS = 9608,
    VERR = 1663,
    VERW = 1669,
    VEXTRACTF128 = 9516,
    VEXTRACTPS = 9491,
    VFMADD132PD = 8387,
    VFMADD132PS = 8374,
    VFMADD132SD = 8413,
    VFMADD132SS = 8400,
    VFMADD213PD = 8667,
    VFMADD213PS = 8654,
    VFMADD213SD = 8693,
    VFMADD213SS = 8680,
    VFMADD231PD = 8947,
    VFMADD231PS = 8934,
    VFMADD231SD = 8973,
    VFMADD231SS = 8960,
    VFMADDSUB132PD = 8326,
    VFMADDSUB132PS = 8310,
    VFMADDSUB213PD = 8606,
    VFMADDSUB213PS = 8590,
    VFMADDSUB231PD = 8886,
    VFMADDSUB231PS = 8870,
    VFMSUB132PD = 8439,
    VFMSUB132PS = 8426,
    VFMSUB132SD = 8465,
    VFMSUB132SS = 8452,
    VFMSUB213PD = 8719,
    VFMSUB213PS = 8706,
    VFMSUB213SD = 8745,
    VFMSUB213SS = 8732,
    VFMSUB231PD = 8999,
    VFMSUB231PS = 8986,
    VFMSUB231SD = 9025,
    VFMSUB231SS = 9012,
    VFMSUBADD132PD = 8358,
    VFMSUBADD132PS = 8342,
    VFMSUBADD213PD = 8638,
    VFMSUBADD213PS = 8622,
    VFMSUBADD231PD = 8918,
    VFMSUBADD231PS = 8902,
    VFNMADD132PD = 8492,
    VFNMADD132PS = 8478,
    VFNMADD132SD = 8520,
    VFNMADD132SS = 8506,
    VFNMADD213PD = 8772,
    VFNMADD213PS = 8758,
    VFNMADD213SD = 8800,
    VFNMADD213SS = 8786,
    VFNMADD231PD = 9052,
    VFNMADD231PS = 9038,
    VFNMADD231SD = 9080,
    VFNMADD231SS = 9066,
    VFNMSUB132PD = 8548,
    VFNMSUB132PS = 8534,
    VFNMSUB132SD = 8576,
    VFNMSUB132SS = 8562,
    VFNMSUB213PD = 8828,
    VFNMSUB213PS = 8814,
    VFNMSUB213SD = 8856,
    VFNMSUB213SS = 8842,
    VFNMSUB231PD = 9108,
    VFNMSUB231PS = 9094,
    VFNMSUB231SD = 9136,
    VFNMSUB231SS = 9122,
    VHADDPD = 4197,
    VHADDPS = 4206,
    VHSUBPD = 4231,
    VHSUBPS = 4240,
    VINSERTF128 = 9503,
    VINSERTPS = 9557,
    VLDDQU = 7001,
    VLDMXCSR = 9941,
    VMASKMOVDQU = 7131,
    VMASKMOVPD = 7949,
    VMASKMOVPS = 7937,
    VMAXPD = 3588,
    VMAXPS = 3580,
    VMAXSD = 3604,
    VMAXSS = 3596,
    VMCALL = 1719,
    VMCLEAR = 9997,
    VMFUNC = 1787,
    VMINPD = 3468,
    VMINPS = 3460,
    VMINSD = 3484,
    VMINSS = 3476,
    VMLAUNCH = 1727,
    VMLOAD = 1811,
    VMMCALL = 1802,
    VMOVAPD = 2476,
    VMOVAPS = 2467,
    VMOVD = 3932,
    VMOVDDUP = 2234,
    VMOVDQA = 3962,
    VMOVDQU = 3971,
    VMOVHLPS = 2195,
    VMOVHPD = 2382,
    VMOVHPS = 2373,
    VMOVLHPS = 2363,
    VMOVLPD = 2214,
    VMOVLPS = 2205,
    VMOVMSKPD = 2836,
    VMOVMSKPS = 2825,
    VMOVNTDQ = 6858,
    VMOVNTDQA = 7905,
    VMOVNTPD = 2593,
    VMOVNTPS = 2583,
    VMOVQ = 3939,
    VMOVSD = 2143,
    VMOVSHDUP = 2391,
    VMOVSLDUP = 2223,
    VMOVSS = 2135,
    VMOVUPD = 2126,
    VMOVUPS = 2117,
    VMPSADBW = 9637,
    VMPTRLD = 9988,
    VMPTRST = 6385,
    VMREAD = 4128,
    VMRESUME = 1737,
    VMRUN = 1795,
    VMSAVE = 1819,
    VMULPD = 3199,
    VMULPS = 3191,
    VMULSD = 3215,
    VMULSS = 3207,
    VMWRITE = 4152,
    VMXOFF = 1747,
    VMXON = 10006,
    VORPD = 3066,
    VORPS = 3059,
    VPABSB = 7695,
    VPABSD = 7725,
    VPABSW = 7710,
    VPACKSSDW = 3859,
    VPACKSSWB = 3691,
    VPACKUSDW = 7926,
    VPACKUSWB = 3769,
    VPADDB = 7211,
    VPADDD = 7241,
    VPADDQ = 6488,
    VPADDSB = 6938,
    VPADDSW = 6955,
    VPADDUSW = 6629,
    VPADDW = 7226,
    VPALIGNR = 9419,
    VPAND = 6613,
    VPANDN = 6672,
    VPAVGB = 6687,
    VPAVGW = 6732,
    VPBLENDVB = 9692,
    VPBLENDW = 9400,
    VPCLMULQDQ = 9658,
    VPCMPEQB = 4052,
    VPCMPEQD = 4090,
    VPCMPEQQ = 7885,
    VPCMPEQW = 4071,
    VPCMPESTRI = 9737,
    VPCMPESTRM = 9714,
    VPCMPGTB = 3711,
    VPCMPGTD = 3749,
    VPCMPGTQ = 8096,
    VPCMPGTW = 3730,
    VPCMPISTRI = 9783,
    VPCMPISTRM = 9760,
    VPERM2F128 = 9265,
    VPERMILPD = 7570,
    VPERMILPS = 7559,
    VPEXTRB = 9437,
    VPEXTRD = 9462,
    VPEXTRQ = 9471,
    VPEXTRW = 6319,
    VPHADDD = 7383,
    VPHADDSW = 7401,
    VPHADDW = 7366,
    VPHMINPOSUW = 8271,
    VPHSUBD = 7459,
    VPHSUBSW = 7477,
    VPHSUBW = 7442,
    VPINSRB = 9538,
    VPINSRD = 9584,
    VPINSRQ = 9593,
    VPINSRW = 6302,
    VPMADDUBSW = 7422,
    VPMADDWD = 7082,
    VPMAXSB = 8182,
    VPMAXSD = 8199,
    VPMAXSW = 6972,
    VPMAXUB = 6656,
    VPMAXUD = 8233,
    VPMAXUW = 8216,
    VPMINSB = 8114,
    VPMINSD = 8131,
    VPMINSW = 6910,
    VPMINUB = 6598,
    VPMINUD = 8165,
    VPMINUW = 8148,
    VPMOVMSKB = 6541,
    VPMOVSXBD = 7764,
    VPMOVSXBQ = 7785,
    VPMOVSXBW = 7743,
    VPMOVSXDQ = 7848,
    VPMOVSXWD = 7806,
    VPMOVSXWQ = 7827,
    VPMOVZXBD = 7992,
    VPMOVZXBQ = 8013,
    VPMOVZXBW = 7971,
    VPMOVZXDQ = 8076,
    VPMOVZXWD = 8034,
    VPMOVZXWQ = 8055,
    VPMULDQ = 7867,
    VPMULHRSW = 7548,
    VPMULHUW = 6749,
    VPMULHW = 6767,
    VPMULLD = 8250,
    VPMULLW = 6504,
    VPMULUDQ = 7063,
    VPOR = 6924,
    VPSADBW = 7100,
    VPSHUFB = 7349,
    VPSHUFD = 4014,
    VPSHUFHW = 4023,
    VPSHUFLW = 4033,
    VPSIGNB = 7495,
    VPSIGND = 7529,
    VPSIGNW = 7512,
    VPSLLD = 7031,
    VPSLLDQ = 9855,
    VPSLLQ = 7046,
    VPSLLW = 7016,
    VPSRAD = 6717,
    VPSRAW = 6702,
    VPSRLD = 6458,
    VPSRLDQ = 9838,
    VPSRLQ = 6473,
    VPSRLW = 6443,
    VPSUBB = 7151,
    VPSUBD = 7181,
    VPSUBQ = 7196,
    VPSUBSB = 6876,
    VPSUBSW = 6893,
    VPSUBUSB = 6561,
    VPSUBUSW = 6580,
    VPSUBW = 7166,
    VPTEST = 7636,
    VPUNPCKHBW = 3791,
    VPUNPCKHDQ = 3837,
    VPUNPCKHQDQ = 3907,
    VPUNPCKHWD = 3814,
    VPUNPCKLBW = 3623,
    VPUNPCKLDQ = 3669,
    VPUNPCKLQDQ = 3882,
    VPUNPCKLWD = 3646,
    VPXOR = 6987,
    VRCPPS = 2967,
    VRCPSS = 2975,
    VROUNDPD = 9305,
    VROUNDPS = 9286,
    VROUNDSD = 9343,
    VROUNDSS = 9324,
    VRSQRTPS = 2933,
    VRSQRTSS = 2943,
    VSHUFPD = 6353,
    VSHUFPS = 6344,
    VSQRTPD = 2888,
    VSQRTPS = 2879,
    VSQRTSD = 2906,
    VSQRTSS = 2897,
    VSTMXCSR = 9970,
    VSUBPD = 3408,
    VSUBPS = 3400,
    VSUBSD = 3424,
    VSUBSS = 3416,
    VTESTPD = 7590,
    VTESTPS = 7581,
    VUCOMISD = 2761,
    VUCOMISS = 2751,
    VUNPCKHPD = 2317,
    VUNPCKHPS = 2306,
    VUNPCKLPD = 2275,
    VUNPCKLPS = 2264,
    VXORPD = 3095,
    VXORPS = 3087,
    VZEROALL = 4118,
    VZEROUPPER = 4106,
    WAIT = 10028,
    WBINVD = 561,
    WRFSBASE = 9931,
    WRGSBASE = 9960,
    WRMSR = 586,
    XADD = 946,
    XCHG = 212,
    XGETBV = 1771,
    XLAT = 400,
    XOR = 61,
    XORPD = 3080,
    XORPS = 3073,
    XRSTOR = 4273,
    XRSTOR64 = 4281,
    XSAVE = 4249,
    XSAVE64 = 4256,
    XSAVEOPT = 4299,
    XSAVEOPT64 = 4309,
    XSETBV = 1779,
    _3DNOW = 10034,
  }

  public enum Register {
    R_RAX,
    R_RCX,
    R_RDX,
    R_RBX,
    R_RSP,
    R_RBP,
    R_RSI,
    R_RDI,
    R_R8,
    R_R9,
    R_R10,
    R_R11,
    R_R12,
    R_R13,
    R_R14,
    R_R15,
    R_EAX,
    R_ECX,
    R_EDX,
    R_EBX,
    R_ESP,
    R_EBP,
    R_ESI,
    R_EDI,
    R_R8D,
    R_R9D,
    R_R10D,
    R_R11D,
    R_R12D,
    R_R13D,
    R_R14D,
    R_R15D,
    R_AX,
    R_CX,
    R_DX,
    R_BX,
    R_SP,
    R_BP,
    R_SI,
    R_DI,
    R_R8W,
    R_R9W,
    R_R10W,
    R_R11W,
    R_R12W,
    R_R13W,
    R_R14W,
    R_R15W,
    R_AL,
    R_CL,
    R_DL,
    R_BL,
    R_AH,
    R_CH,
    R_DH,
    R_BH,
    R_R8B,
    R_R9B,
    R_R10B,
    R_R11B,
    R_R12B,
    R_R13B,
    R_R14B,
    R_R15B,
    R_SPL,
    R_BPL,
    R_SIL,
    R_DIL,
    R_ES,
    R_CS,
    R_SS,
    R_DS,
    R_FS,
    R_GS,
    R_RIP,
    R_ST0,
    R_ST1,
    R_ST2,
    R_ST3,
    R_ST4,
    R_ST5,
    R_ST6,
    R_ST7,
    R_MM0,
    R_MM1,
    R_MM2,
    R_MM3,
    R_MM4,
    R_MM5,
    R_MM6,
    R_MM7,
    R_XMM0,
    R_XMM1,
    R_XMM2,
    R_XMM3,
    R_XMM4,
    R_XMM5,
    R_XMM6,
    R_XMM7,
    R_XMM8,
    R_XMM9,
    R_XMM10,
    R_XMM11,
    R_XMM12,
    R_XMM13,
    R_XMM14,
    R_XMM15,
    R_YMM0,
    R_YMM1,
    R_YMM2,
    R_YMM3,
    R_YMM4,
    R_YMM5,
    R_YMM6,
    R_YMM7,
    R_YMM8,
    R_YMM9,
    R_YMM10,
    R_YMM11,
    R_YMM12,
    R_YMM13,
    R_YMM14,
    R_YMM15,
    R_CR0,
    R_UNUSED0,
    R_CR2,
    R_CR3,
    R_CR4,
    R_UNUSED1,
    R_UNUSED2,
    R_UNUSED3,
    R_CR8,
    R_DR0,
    R_DR1,
    R_DR2,
    R_DR3,
    R_UNUSED4,
    R_UNUSED5,
    R_DR6,
    R_DR7,
  }
}
