using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Battle
    {
        
        //INSTANCES

        //the characters, gets new subclasses if your current fighter dies and you have someone alive
        Character yourChar = new Character();
        Character opponentChar = new Character();

        //The attacks, gets new subclasses each round based on what is picked and maybe transformed
        Attack yourAttack = new Attack();
        Attack opponentAttack = new Attack();

        //Index som används för NPCs AI
        int yourLastAttackIndex = 1;



        //ATTACKS

        //If the player chose an attack or not
        bool didChoose;

        //Are used to define which attack is chosen or randomized
        int attackIndex = 0;
        int oppAttackIndex = 0;

        //Can do the behavior special, only once per game so is created here
        bool canDoBehavior = true;
        bool opponentCanDoBehavior = true;

        //The varible that the damage is built upon, base is 10
        double damageDealt = 10;


        //EN Queue för lite speciell AI NPC ojojoj
        Queue<int> attackQueue = new Queue<int>();
        List<int> attacks = new List<int>();
        


        //If you won the game
        bool didWin;

        //if the entire fight is done or not
        bool done = false;

        //the damage you've done during the entire game
        double totalDealt;
        double totalTaken;
        double highscore;





        //Huvudmetoden som kör den mesta gränssnittet och kör alla andra metoder
        public bool Fight(List<Character> yourCharacters, List<Character> opponentCharacters)
        {
            //Integers som används för en highscore funktion som körs i slutet av fighten
            totalDealt = 0;
            totalTaken = 0;
            highscore = 0;

            //Skapar en individuell instans av båda lagens första karaktär och tar bort den från listorna.
            yourChar = yourCharacters[0];
            yourCharacters.Remove(yourChar);
            opponentChar = opponentCharacters[0];
            opponentCharacters.Remove(opponentChar);
            Console.WriteLine("First off, " + yourChar.name + " vs. " + opponentChar.name);
            Console.WriteLine("");
            Console.WriteLine("Time to fight!");
            Console.ReadLine();
            Console.Clear();


            //körs tills alla fighters på något lag är döda
            while (done == false) 
            {

                //Remaining HP
                Console.WriteLine(yourChar.name + "'s remaining HP: " + yourChar.HP);
                Console.WriteLine(opponentChar.name + "'s remaining HP: " + opponentChar.HP);



                //Pick your Attack
                yourAttack = ChooseAttack();

                
                //Körs bara om man valde en attack
                if (didChoose == true)
                {

                    //Opponents Attack
                    opponentAttack = OpponentAttack();


                    Console.Clear();

                    // Attack UI
                    Console.WriteLine("You chose " + yourAttack.name);
                    Console.WriteLine("Your opponent chose " + opponentAttack.name);


                    //Quicks Passive
                    YourPassive(0);
                    OpponentPassive(0);

                    
                    
                    
                    //TRANSFORMATION
                    yourAttack = YourTransformation();

                    

                    // Enemy transformation
                    opponentAttack = EnemyTransformation();


                    //För möjlig smart NPC attack
                    yourLastAttackIndex = attackIndex;


                }

                //körs bara om någon inte valde att blocka
                if (yourAttack.name != "Block" && opponentAttack.name != "Block")
                {

                    // Which attack wins
                    WinOrLoose(yourChar, yourAttack, oppAttackIndex);
                    WinOrLoose(opponentChar, opponentAttack, attackIndex);




                    // Who wins and does the damage
                    WhoWins();




                    //Every characters specific passives
                    YourPassive(3);
                    OpponentPassive(3);


                    



                    //If your fighter dies
                    CheckDeath(yourCharacters);

                    //If opponent fighter dies
                    OpponentCheckDeath(opponentCharacters);


                }
                else if (yourAttack.name == "Block")
                {
                    Console.WriteLine(yourChar.name + " blocked " + opponentChar.name + "'s attack!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(opponentChar.name + " blocked " + yourChar.name + "'s attack!");
                    Console.ReadLine();
                }


                Console.Clear();

            }

            highscore = totalDealt - totalTaken;
            Console.WriteLine("Your highscore: " + highscore);

            return didWin;

        }





        //Choose Your Attack
        public Attack ChooseAttack()
        {

            Console.WriteLine("Choose your attack!");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");
            Console.WriteLine("4. Lizard");
            Console.WriteLine("5. Spock");

            /* TIMER - funkade inte så struntade i det för nu

            Timer timer1 = new Timer(1000);
            timer1.Elapsed += Timer_Elapsed;
            timer1.Start();
            */



            string attackSelection = Console.ReadLine();
            bool attackSuccess = int.TryParse(attackSelection, out attackIndex);

            if (attackSuccess == false || attackIndex < 1 || attackIndex > 5)
            {
                Console.WriteLine("You failed to choose an attack!");

                didChoose = false;
                //timer1.Stop();
            }
            else
            {
                didChoose = true;
                //timer1.Stop();
            }

            yourAttack = YourAttack();
            return yourAttack;
        }

        //Whats attack did the input corralate to
        public Attack YourAttack()
        {
            if (didChoose == true)
            {
                yourAttack = WhichAttack(attackIndex);
            }
            else
            {
                yourAttack = new None();
            }

            return yourAttack;
        }


        //Randomized Attack
        public Attack OpponentAttack()
        {
            Random opponentAttackGen = new Random();

            //Slumpar ifall NPCn kommer vara "smart" och väljer att köra den attack spelaren valde förra rundan, 20%s chans
            int oppAttackSmart = opponentAttackGen.Next(0, 100);

            //Om inte körs denna, som lägger till attacker i en kö som används i 5 rundor (om den inte kör en "smart" runda då kön bara pausas)
            if (oppAttackSmart < 80)
            {
                //Om kön är tom fylls den på igen
                if (attackQueue.Count == 0)
                {

                    //Först läggs 5 integers in i en lista för att representera attackernas index

                    attacks.Add(1);
                    attacks.Add(2);
                    attacks.Add(3);
                    attacks.Add(4);
                    attacks.Add(5);

                    //Sen körs en forloop med nedåtgående i-variabel, där en int får ett slumpat värde mellan 1 och i-variabeln (därför den går ner och inte upp)
                    //den slumpade siffran läggs till i en kö medans attack-indexet tas bort från listan
                    //loopen körs om tills siffrorna 1-5 har lagts till i kön i slumpad ordning
                    for (int i = 6; i > 1; i--)
                    {
                        oppAttackIndex = opponentAttackGen.Next(1, i);

                        attackQueue.Enqueue(attacks[oppAttackIndex - 1]);
                        attacks.Remove(attacks[oppAttackIndex - 1]);
                    }

                    //Köns första siffra tas bort och används i WhichAttack-metoden, där den speglas mot attack-indexen för att välja indexets attack som attack för denna runda.
                    oppAttackIndex = attackQueue.Dequeue();
                    opponentAttack = WhichAttack(oppAttackIndex);
                }
                else
                {

                    //Om kön inte är tom körs enbart deQueue-momentet
                    oppAttackIndex = attackQueue.Dequeue();
                    opponentAttack = WhichAttack(oppAttackIndex);

                }
            }
            else
            {
                //är då "smart" och väljer attacken som spelaren valde senaste rundan
                
                oppAttackIndex = yourLastAttackIndex;
                opponentAttack = WhichAttack(oppAttackIndex);
            }


            
            

            return opponentAttack;
        }
        


        //Which Attack was chosen - baseras på int-indexet som valdes i YourAttack och OpponentAttack och returnerar valda attacken
        public Attack WhichAttack(int index)
        {


            Attack whichYourAttack = new Attack();

            if (index == 1)
            {
                whichYourAttack = new Rock();
            }
            else if (index == 2)
            {
                whichYourAttack = new Paper();
            }
            else if (index == 3)
            {
                whichYourAttack = new Scissors();
            }
            else if (index == 4)
            {
                whichYourAttack = new Lizard();
            }
            else
            {
                whichYourAttack = new Spock();
            }

            return whichYourAttack;

        }


        





        //Gränsnitt och metodik över ifall spelaren ska transformera sin attack
        public Attack YourTransformation()
        {
            Console.WriteLine("");
            Console.WriteLine("Do you wanna transform your attack?");

            //Skriver ut specialattacken eller att man inte kan använda den
            yourChar.BehaviorSpecial(canDoBehavior);

            //instansierar den valda attackens vanliga transformationer        
            yourAttack.Transform();

            //Skriver ut transformationerna eller att man inte kan använda de
            yourAttack.Transformations(yourChar.specials);



            //Choose transformation

            string transform = Console.ReadLine();
            int transformIndex;
            bool transformSuccess = int.TryParse(transform, out transformIndex);

            if (transformSuccess == false || transformIndex > 3 || transformIndex < 1)
            {
                Console.WriteLine("You chose not to transform!");

            }
            //ifall man valde att använda sin behaviorAttack
            else if (transformIndex == 1)
            {
                if (canDoBehavior == true)
                {
                    Console.WriteLine("You chose to transform your " + yourAttack.name + " into a " + yourChar.behaviorAttack.name);
                    yourAttack = yourChar.behaviorAttack;

                    //Kan bara köras en gång per match
                    canDoBehavior = false;
                }
                else
                {
                    Console.WriteLine("You have already used your Behavior transformation for this game!");
                }
            }
            //om man valde någon av sina vanliga transformations
            else if (yourChar.specials > 0)
            {
                if (transformIndex == 2)
                {
                    Console.WriteLine("You chose to transform your " + yourAttack.name + " into a " + yourAttack.firstTransform.name);
                    yourAttack = yourAttack.firstTransform;

                    //En get-set som subtraherar 1 till en int, om den når 0 kan man inte använda den igen. 
                    yourChar.Specials = 1;
                }
                else if (transformIndex == 3)
                {
                    Console.WriteLine("You chose to transform your " + yourAttack.name + " into a " + yourAttack.secondTransform.name);
                    yourAttack = yourAttack.secondTransform;
                    yourChar.Specials = 1;
                }
            }
            else if (yourChar.specials == 0 && (transformIndex == 2 || transformIndex == 3))
            {
                Console.WriteLine("You have already used this fighter's 2 transformations!");
            }
            

            return yourAttack;

        }
        
        public Attack EnemyTransformation()
        {
            Random transformGen = new Random();
            int transformInt = transformGen.Next(100);
            if (transformInt < 10)
            {

                //Slumpar bara om den har möjlighet att göra någon transformation
                if (opponentChar.Specials > 0 && opponentCanDoBehavior == true)
                {
                    transformInt = transformGen.Next(0, 3);
                }
                else if (opponentChar.Specials == 0)
                {
                    transformInt = 0;
                }
                else if (opponentCanDoBehavior == false)
                {
                    transformInt = transformGen.Next(1, 3);
                }

                //Instansierar attackens transformationer
                opponentAttack.Transform();


                if (transformInt == 0)
                {
                    Console.WriteLine("Your enemy chose to transform their " + opponentAttack.name + " into a " + opponentChar.behaviorAttack.name);
                    opponentAttack = opponentChar.behaviorAttack;
                }
                else if (transformInt == 1)
                {
                    Console.WriteLine("Your opponent chose to transform their " + opponentAttack.name + " into a " + opponentAttack.firstTransform.name);
                    opponentAttack = opponentAttack.firstTransform;
                }
                else
                {
                    Console.WriteLine("Your opponent chose to transform their " + opponentAttack.name + " into a " + opponentAttack.secondTransform.name);
                    opponentAttack = opponentAttack.secondTransform;
                }
            }
            else
            {
                Console.WriteLine("Your opponent chose not to transform!");
            }

            return opponentAttack;
        }




        //Körs för båda karaktärer, använde rmotståndarens attackIndex för att få tillbaka ett int-värde från attack-klass-metoden som beskriver hur bra ens attack är emot den andras
        //den sparas i en get-set metod i karaktären som sedan avnänds...
        public void WinOrLoose(Character chara, Attack attack, int index)
        {
            chara.Against = attack.Against(index);
            
        }

        //... i denna metod, då jag jämför de två karaktärernas against-värde för att se vem som vann.
        public void WhoWins()
        {
            
            if (yourChar.Against > opponentChar.Against)
            {
                Console.WriteLine("You Win!");

                yourChar.wonRound = true;
                opponentChar.wonRound = false;

                DealDamage();
            }
            else if (yourChar.Against < opponentChar.Against)
            {
                Console.WriteLine("You Loose!");

                yourChar.wonRound = false;
                opponentChar.wonRound = true;

                TakeDamage();

            }
            else
            {
                Console.WriteLine("It's a Draw!");

                yourChar.wonRound = false;
                opponentChar.wonRound = false;
            }

            Console.ReadLine();
        }





        //Calculating Damage
        public void DealDamage()
        {
            //main damage
            damageDealt += yourAttack.DoDamage() + yourChar.DoDamage();


            //Combo, om man vann ökar ens combo och om man förlorade blir den 0 (getset)
            opponentChar.Streak = 0;
            yourChar.Streak = 1;

            //Lite matteskit där jag tar attackens kombo-värde * karaktärens kombovärde upphöjt i ens streak / 2, skulle behöva mer tuning och balans
            double comboValue = Math.Pow((yourAttack.combo * yourChar.combo), yourChar.Streak / 2);
            Console.WriteLine(yourChar.name + "'s Combo Bonus: " + comboValue);
            damageDealt *= comboValue;


            //crits
            Random critGen = new Random();
            int hit = critGen.Next(100);

            if (hit <= (yourAttack.criticalHit + yourChar.criticalHit) / 2)
            {
                //Sledges passive - kan inte bli crittad
                if (yourChar.whenPassive == 1)
                {
                    YourPassive(1);
                }

                //for basically every character
                else
                {
                    Console.WriteLine("It's a crit!");
                    damageDealt *= 2;
                }
            }








            //defense
            damageDealt = damageDealt - (opponentAttack.TakeDamage() + opponentChar.TakeDamage());


            //minsta värdet som man kan skada om man vann är 5
            if (damageDealt < 5)
            {
                damageDealt = 5;
            }



            //Passive
            Random invisGen = new Random();
            int invisPas = invisGen.Next(100);

            //The Invisible kan missa skada om man slumpar rätt
            if (opponentChar.whenPassive == 2 && invisPas < 15)
            {
                OpponentPassive(2);

            }
            else
            {
                opponentChar.LostHealth = damageDealt;
            }

            totalDealt += damageDealt;


            Console.WriteLine(yourChar.name + " dealt " + damageDealt + " damage to " + opponentChar);
            
        }


        //Samma som dealdamage fsat för fienden
        public void TakeDamage()
        {
            // main damage
            damageDealt = damageDealt + opponentAttack.DoDamage() + opponentChar.DoDamage();

            //combo
            yourChar.Streak = 0;
            opponentChar.Streak = 1;
            double comboValue = Math.Pow((opponentAttack.combo * opponentChar.combo), opponentChar.Streak / 2);
            Console.WriteLine(opponentChar.name + "'s Combo Bonus: " + comboValue);
            damageDealt *= comboValue;

            

                //crit
            Random critGen = new Random();
            int hit = critGen.Next(100);

            if (hit <= (opponentAttack.criticalHit + opponentChar.criticalHit) / 2)
            {

                //Sledges passive
                if (opponentChar.whenPassive == 1)
                {
                    OpponentPassive(1);
                }

                //for basically every character
                else
                {
                    Console.WriteLine("It's a crit!");
                    damageDealt *= 2;
                }
                    
                
            }


            

            


            //taken
            damageDealt = damageDealt - (yourAttack.TakeDamage() + yourChar.TakeDamage());

            if (damageDealt < 5)
            {
                damageDealt = 5;
            }



            //Passives
            Random invisGen = new Random();
            int invisPas = invisGen.Next(100);

            if (yourChar.whenPassive == 2 && invisPas < 15)
            {
                YourPassive(2);

            }
            else
            {
                yourChar.LostHealth = damageDealt;
            }

            totalTaken += damageDealt;

            Console.WriteLine(opponentChar.name + " dealt " + damageDealt + " damage to " + yourChar);
        }



        //Passives
        public void YourPassive(int whenPassive)
        {
            //Kör karaktärens passive om dess whenPassive int stämmer överens med inten som skrivs när metoden kallas.
            //Detta för att olika karaktärers passives körs vid olika tillfällen.
            //Vissa körs även direkt i koden på vissa ställen och har då ingen direkt sak här.
            //Denna metod leder till en virtual method i CHaracter som sedan overridas i karaktärens kod.
            if (yourChar.whenPassive == whenPassive)
            {
                yourChar.Passive(opponentChar, yourAttack, opponentAttack);
            }

        }

        //samma fst fiendens
        public void OpponentPassive(int whenPassive)
        {
            if (opponentChar.whenPassive == whenPassive)
            {
                opponentChar.Passive(yourChar, opponentAttack, yourAttack);
            }
        }




        //Checks if the fighters die
        public void CheckDeath(List<Character> yourCharacters)
        {
            //Har den mindre än 0 hp?
            if (yourChar.HP < 0)
            {
                Console.Clear();
                Console.WriteLine(yourChar.name + " can no longer fight!");

                //Har du några karaktärer kvar eller var denna den sista?
                if (yourCharacters.Count != 0)
                {
                    //Om du har karaktärer kvar byts din karaktär-instans ut mot nästa i din lista och den tas bort från listan.
                    yourChar = yourCharacters[0];
                    yourCharacters.Remove(yourChar);
                    Console.WriteLine(yourChar.name + " jumps in!");
                    yourChar.HP = 100;
                }
                //Om den var sista förlorar du och fighten är över
                else                
                {
                    Console.WriteLine("All your fighters are unable to continue!");
                    didWin = false;

                    done = true;
                }

                Console.ReadLine();
            }
        }

        //Samma fast fiende
        public void OpponentCheckDeath(List<Character> opponentCharacters)
        {
            if (opponentChar.HP < 0)
            {
                Console.Clear();
                Console.WriteLine(opponentChar.name + " can no longer fight!");

                if (opponentCharacters.Count != 0)
                {
                    opponentChar = opponentCharacters[0];
                    opponentCharacters.Remove(opponentChar);
                    Console.WriteLine(opponentChar.name + " jumps in!");                    
                    opponentChar.HP = 100;
                }
                else
                {
                    Console.WriteLine("All your opponent's fighters are unable to continue!");
                    didWin = true;

                    done = true;
                }

                Console.ReadLine();
            }

            
        }



        
    }
}
