using System;
using System.Collections.Generic;
using System.Text;

namespace AstronoSound.Attributs
{
	[Flags]
	public enum Genre : int	//Représente tous les genres musicaux reconnus par notre application: Association possible
	{
		Disco = 0,
		Dancehall = 1,
		Blues = 2,
		Funk = 4,
		Jazz = 8,
		Metal = 16,
		Pop = 32,
		Punk = 64,
		Rap = 128,
		Rocknroll = 256,
		Country = 512,
		Reggae = 1024,
		Afro = 2048,
		Raï = 4096,
		Ska = 8192,
		Gospel = 16384,
		Soul = 32768,
		Kompa = 65536,
		Classique = 131072,
		RnB = 262144,
		Electro = 524288,
		Zouk = 1048576,
		Makossa = 2097152,
		MusiqueIndi = 4194304,
		MusiqueLatino = 8388608,
		HardRock = 16777216,
		Krock = 33554432,
		Krap = 67108864,
		Kindie = 134217728,
		Kpop = 268435456
	}
}
