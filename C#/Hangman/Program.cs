using System;
namespace Methodtesting {

	class main {
		public static void Main(string[] args) {
			bool svarGivet = false;
			bool singleplayer = false;
			bool multiplayer = false;

			Console.Clear();
			visuals.hangman();
			Console.WriteLine("\nGame modes:");
			Console.WriteLine("1) Singleplayer");
			Console.WriteLine("2) Multiplayer");

			while (!svarGivet) {
				string gm_svar = Console.ReadLine();
				if (gm_svar == "1") {
					// Single player
					svarGivet = true;
					singleplayer = true;
				} else if (gm_svar == "2") {
					// Multilplayer
					svarGivet = true;
					multiplayer = true;
				} else {
					// Ilegal argument
					Console.WriteLine("Du skal vælge 1 eller 2 ikke '" + gm_svar + "'");
				}
			}
			bool level_sætning = false;
			bool level = false;
			bool level_ord = false;
			Console.Clear();
			if (singleplayer) {
				visuals.hangman();
				Console.WriteLine(" - Singleplayer");

				int space = 2;
				visuals.spacing(space);
				Console.WriteLine("Levels:");
				Console.WriteLine("1) Ord");
				Console.WriteLine("2) Sætninger");
				
				while (!level) {
					string level_svar = Console.ReadLine();
					if (level_svar == "1") {
						// ord
						level = true;
						level_ord = true;
					} else if (level_svar == "2") {
						// sætninger
						level = true;
						level_sætning = true;
					} else {
						Console.WriteLine("Du skal vælge 1 eller 2 ikke '" + level_svar + "'");
					}
				}
				Console.Clear();
				char[] ord = {' '};
				if (level_ord || !level_sætning) {
					string[] s_ordliste = { "vandmelon", "bus", "bord", "vindue", "tavle", "stol", "trappe", "jakke", "sko", "briller", "bygning", "projektor", "telefon", "blyant", "skoletaske" };

					// Vælger et tilfældigt ord fra s_ordliste
					Random rnd = new Random();
					int n = rnd.Next(0, s_ordliste.Length);
					ord = s_ordliste[n].ToCharArray();
				} else if (!level_ord || level_sætning) {
					string[] s_ordliste = { "dette er en sætning", "en sætning har flere ord" };

					// Vælger et tilfældig sætning fra s_ordliste
					Random rnd = new Random();
					int n = rnd.Next(0, s_ordliste.Length);
					ord = s_ordliste[n].ToCharArray();
				}
				Console.Clear();
				gameClass.game(ord, multiplayer, singleplayer, level_sætning);
			}

			if (multiplayer) {
				visuals.hangman();
				Console.WriteLine(" - Mulitplayer");
				int space = 2;
				visuals.spacing(space);
		
				Console.Write("Player 1 indtast et ord/sætning: ");
				string m_ord = Console.ReadLine().ToLower();

				char[] ord = m_ord.ToCharArray();
				Console.Clear();
				gameClass.game(ord, multiplayer, singleplayer, level_sætning);
			}
		}
	}

	public class gameClass {
		public static void game(char[] ord, bool multiplayer, bool singleplayer, bool level_sætning) {
			// Laver bogstaverne om til "-"
			char[] Gættet = new char[ord.Length];
			for (int i = 0; i < ord.Length; i++) {
				Gættet[i] = '-';
			}
			
			// Finder hvor mange forskellige bogstaver der er i ordet
			// Liste med bool af alfabetet
			bool[] arr = new bool[30];
			arr[0] = false; arr[1] = false; arr[2] = false; arr[3] = false; arr[4] = false; arr[5] = false; arr[6] = false;
			//  a              b                c               d              e               f                g
			arr[7] = false; arr[8] = false; arr[9] = false; arr[10] = false; arr[11] = false; arr[12] = false; arr[13] = false;
			//  h               i               j               k                l                 m                n
			arr[14] = false; arr[15] = false; arr[16] = false; arr[17] = false; arr[18] = false; arr[19] = false; arr[20] = false;
			//  o                p                q               r                  s               t                 u
			arr[21] = false; arr[22] = false; arr[23] = false; arr[24] = false; arr[25] = false; arr[26] = false; arr[27] = false;
			//  v                w                x                y                z                æ                 ø
			arr[28] = false; arr[29] = false;
			//  å

			for (int i = 0; i < ord.Length; i++) {
				int ordetsLængde = ord[i];
				switch (ordetsLængde) {
					case 'a':
						arr[0] = true;
						break;
					case 'b':
						arr[1] = true;
						break;
					case 'c':
						arr[2] = true;
						break;
					case 'd':
						arr[3] = true;
						break;
					case 'e':
						arr[4] = true;
						break;
					case 'f':
						arr[5] = true;
						break;
					case 'g':
						arr[6] = true;
						break;
					case 'h':
						arr[7] = true;
						break;
					case 'i':
						arr[8] = true;
						break;
					case 'j':
						arr[9] = true;
						break;
					case 'k':
						arr[10] = true;
						break;
					case 'l':
						arr[11] = true;
						break;
					case 'm':
						arr[12] = true;
						break;
					case 'n':
						arr[13] = true;
						break;
					case 'o':
						arr[14] = true;
						break;
					case 'p':
						arr[15] = true;
						break;
					case 'q':
						arr[16] = true;
						break;
					case 'r':
						arr[17] = true;
						break;
					case 's':
						arr[18] = true;
						break;
					case 't':
						arr[19] = true;
						break;
					case 'u':
						arr[20] = true;
						break;
					case 'v':
						arr[21] = true;
						break;
					case 'w':
						arr[22] = true;
						break;
					case 'x':
						arr[23] = true;
						break;
					case 'y':
						arr[24] = true;
						break;
					case 'z':
						arr[25] = true;
						break;
					case 'æ':
						arr[26] = true;
						break;
					case 'ø':
						arr[27] = true;
						break;
					case 'å':
						arr[28] = true;
						break;
					case ' ':
						arr[29] = true;
						break;
				}
			}

			// Tjekker hvor mange bogstavs booleans der er true
			int tforsøg = 0;
			for (int i = 0; i < arr.Length; i++) {
				if (arr[i] == true) {
					tforsøg = tforsøg + 1;
				}
			}

			// Ganger hvor mange forskellige bogstaver der er med 2
			tforsøg = (tforsøg * 2);
			if (level_sætning) {

			} else {
				if (tforsøg < 5) {
					tforsøg = 5;
				} else if (tforsøg > 20) {
					tforsøg = 20;
				}
			}

			

			int forsøg = 0;
			bool checkord = true;
			char[] brugteBogstaver = new char[tforsøg];
			bool bogstav_igen = false;
			char gæt = ' ';

			while (checkord) {
				bool vundet = true;
				int forsøgTilbage = tforsøg - forsøg;

				// Hvis et bogstav er brugt skriver den det ud her
				if (bogstav_igen) {
					int space = 4;
					visuals.spacing(space);
					Console.WriteLine("OBS: Du har allerede brugt '" + gæt + "'");
				} else {
					int space = 5;
					visuals.spacing(space);
				}
				bogstav_igen = false;

				// Skrift forskel på single player og multiplayer
				if (multiplayer) {
					Console.WriteLine("\nPlayer 2 Gæt et ord/sætning på " + ord.Length + " bogstaver (mellemrum inkluderet)");
				} else {
					Console.WriteLine("\nGæt et ord på " + ord.Length + " bogstaver");
				}

				Console.WriteLine("Brugte bogstaver: " + "{0}", string.Join(" ", brugteBogstaver));
				Console.WriteLine("Du har " + forsøgTilbage + " forsøg tilbage. Gættede bogstaver:");
				Console.WriteLine(Gættet);
				Console.Write("Gæt: ");

				string tempString = Console.ReadLine().ToLower();
				gæt = tempString[0];

				// Finder ud af om gæt allerede er et brugt bogstav
				for (int i = 0; i < brugteBogstaver.Length; i++) {
					if (gæt == brugteBogstaver[i]) {
						bogstav_igen = true;
					}
				}

				// Skriver bogstavet på den rette plads i stedet for "-"
				for (int i = 0; i < ord.Length; i++) {
					if (ord[i] == gæt) {
						Gættet[i] = gæt;
					}
				}

				// Tjekker om der er flere "-"
				for (int i = 0; i < ord.Length; i++) {
					if (Gættet[i] == '-') {
						vundet = false;
					}
				}
				Console.Clear();
				// Putter det bogstav i listen med brugte bogstaver
				brugteBogstaver[forsøg] = gæt;
				forsøg++;

				// Tjekker om der spillet single- eller multiplayer og om player 1 eller player 2 vandt
				if (singleplayer || !multiplayer) {
					if (forsøgTilbage == 1) {
						int space = 3;
						visuals.spacing(space);
						visuals.hangman();
						Console.WriteLine("GAME OVER! Ordet/sætningen var: " + "{0}", string.Join("", ord));
						checkord = false;
					} else if (vundet == true) {
						Console.Clear();
						int space = 3;
						visuals.spacing(space);
						visuals.hangman();
						Console.WriteLine("Du vinder! Ordet/sætningen var: " + "{0}", string.Join("", ord));
						checkord = false;
					}
				} else if (!singleplayer || multiplayer) {
					if (forsøgTilbage == 1) {
						int space = 3;
						visuals.spacing(space);
						visuals.hangman();
						Console.WriteLine("Player 1 vinder! Ordet/sætningen var: " + "{0}", string.Join("", ord));
						checkord = false;
					} else if (vundet == true) {
						Console.Clear();
						int space = 3;
						visuals.spacing(space);
						visuals.hangman();
						Console.WriteLine("Player 2 vinder! Ordet/sætningen var: " + "{0}", string.Join("", ord));
						checkord = false;
					}
				}
			}
		}
	}

	public class visuals {
		public static void hangman() {
			Console.WriteLine("\n");
			Console.WriteLine("{}    {}    {}{}    {}    {}   {}}}}}   {}      {}    {}{}    {}    {}");
			Console.WriteLine("{}    {}   {}  {}   {}}}  {}  {}    {}  {}}}  {{{}   {}  {}   {}}}  {}");
			Console.WriteLine("{}{{}}{}  {}{{}}{}  {} {} {}  {}        {} {{}} {}  {}{{}}{}  {} {} {}");
			Console.WriteLine("{}    {}  {}    {}  {}  {{{}  {}  {{{}  {}      {}  {}    {}  {}  {{{}");
			Console.WriteLine("{}    {}  {}    {}  {}    {}   {}}}}}   {}      {}  {}    {}  {}    {}");
		}
		public static void spacing(int space) {
			for (int i = 0; i < space; i++) {
				Console.WriteLine("");
			}
		}
	}
}