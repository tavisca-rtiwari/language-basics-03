using System;
using System.Linq;
using System.Collections;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {   int [] re=SelectMeals(protein, carbs, fat, dietPlans);
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
            // for(int i=0;i<re.Length;i++){
            //     Console.Write($"{re[i]} ");
            // }
            // Console.WriteLine("");
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {   int P=0,p=121,C=0,c=101,F=0,f=101,T=0,t=1301,len=protein.Length,k=0,len_diet=dietPlans.Length;
            int[] result = new int[len_diet];
            for(int i=0;i<len;i++){
                k=((protein[i]+carbs[i])*5+fat[i]*9);
                if(protein[i]>P)P=protein[i];
                if(protein[i]<p)p=protein[i];
                if(carbs[i]>C)C=carbs[i];
                if(carbs[i]<c)c=carbs[i];
                if(fat[i]>F)F=fat[i];
                if(fat[i]<f)f=fat[i];
                if(k>T)T=k;
                if(k<t)t=k;
            }
            for(int i=0;i<len_diet;i++){
                ArrayList temp = new ArrayList();
                if(String.Equals(dietPlans[i],""))continue;
                for(int j=0;j<dietPlans[i].Length;j++){
                    if(dietPlans[i][j]=='P'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(protein[l]==P){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                                if(protein[(int)temp[l]]>protein[(int)temp[l+1]])temp.RemoveAt(l+1);
                            }
                        }
                    }
                    if(dietPlans[i][j]=='p'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(protein[l]==p){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                                if(protein[(int)temp[l]]>protein[(int)temp[l+1]])temp.RemoveAt(l);
                            }
                        }
                    }
                     if(dietPlans[i][j]=='C'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(carbs[l]==C){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                                if(carbs[(int)temp[l]]>carbs[(int)temp[l+1]])temp.RemoveAt(l+1);
                            }
                        }
                    }
                     if(dietPlans[i][j]=='c'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(carbs[l]==c){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                                if(carbs[(int)temp[l]]>carbs[(int)temp[l+1]])temp.RemoveAt(l);
                            }
                        }
                    }
                    if(dietPlans[i][j]=='F'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(fat[l]==F){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                                if(fat[(int)temp[l]]>fat[(int)temp[l+1]])temp.RemoveAt(l+1);
                            }
                        }
                    }
                    if(dietPlans[i][j]=='f'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(fat[l]==f){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                                if(fat[(int)temp[l]]>fat[(int)temp[l+1]])temp.RemoveAt(l+1);
                            }
                        }
                    }
                    if(dietPlans[i][j]=='T'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(((protein[l]+carbs[l])*5+fat[l]*9)==T){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                            if(((protein[(int)temp[l]]+carbs[(int)temp[l]])*5+fat[(int)temp[l]]*9)>((protein[(int)temp[l+1]]+carbs[(int)temp[l+1]])*5+fat[(int)temp[l+1]]*9))temp.RemoveAt(l+1);
                            }
                        }
                    }
                    if(dietPlans[i][j]=='t'){
                        if(temp.Count==0){
                            for(int l=0;l<len;l++){
                                if(((protein[l]+carbs[l])*5+fat[l]*9)==t){
                                    temp.Add(l);
                                }
                            }
                        }
                        else{
                            for(int l=0;l<temp.Count-1;l++){
                                if(((protein[(int)temp[l]]+carbs[(int)temp[l]])*5+fat[(int)temp[l]]*9)>((protein[(int)temp[l+1]]+carbs[(int)temp[l+1]])*5+fat[(int)temp[l+1]]*9))temp.RemoveAt(l);
                            }
                        }
                    }
                }
                if(temp.Count>1){
                    for(int m=0;m<temp.Count-1;m++){
                        if(fat[(int)temp[m]]>fat[(int)temp[m+1]])temp.RemoveAt(m+1);
                    }
                }
                result[i]=(int)temp[0];
            }

            //throw new NotImplementedException();
        return result;
        }
    }
}