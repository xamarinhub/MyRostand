using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRostand.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfil : ContentPage
    {
        public UserProfil()
        {
            Title = "Mon Profil";
            InitializeComponent();
            var value = Application.Current.Properties["AppUser"];
            String id = value.ToString();
            String nom = "";
            String prenom = "";
            String telephone = "";           
            var datenaissance = new DateTime(2008, 3, 1, 7, 0, 0);
            String mail = "";
            String rue = "";
            String codpost = "";
            String ville = "";
            String mdp = "";
            String rolelibelle = "";
            List<User> LeUser = Database.MyCantineSQL.UnUser(id);
            for (int i = 0; i < LeUser.Count; i++)
            {
                User UnUser = LeUser[i];
                nom = UnUser.Nom;
                prenom = UnUser.Prenom;              
                telephone = UnUser.Telephone;
                datenaissance = UnUser.DateNaissance;
                mail = UnUser.Mail;
                rue = UnUser.Rue;
                codpost = UnUser.CodePostal;
                ville = UnUser.Ville;
                mdp = UnUser.MDP;
                rolelibelle = UnUser.Rolelibelle;
            }

            StackLayout Layout1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 80, 50, 20)
            };
            var labelNom = new Label
            {
                Text = " Nom : ",                
                FontSize = 30
            };
            var labelNom2 = new Label
            {
                Text = nom,
                FontSize = 30
            };

            StackLayout Layout2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };

            var labelPrenom = new Label
            {
                Text = " Prenom : ",
                FontSize = 30
            };
            var labelPrenom2 = new Label
            {
                Text = prenom,
                FontSize = 30
            };
            StackLayout Layout4 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };

            var labelTel= new Label
            {
                Text = " Telephone : ",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 30
            };
            var MyEntryTel = new Entry { Text = "", Placeholder = telephone + "  " , FontSize = 30, Keyboard = Keyboard.Numeric };

            StackLayout Layout5 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelDateN = new Label
            {
                Text = " Date de Naissance : ",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 30
            };
            
            var MyEntryDateN = new DatePicker { FontSize = 30, Date = datenaissance, IsEnabled = false  };

            StackLayout Layout6 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelEMAIL = new Label
            {
                Text = " Adresse Mail : ",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 30
            };
            var MyEntryEMAIL = new Entry { Text = "", Placeholder = mail + "                             ", FontSize = 30 };


            StackLayout Layout7 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelRUE = new Label
            {
                Text = " Rue : ",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 30
            };

            var MyEntryRue = new Entry { Text = "", Placeholder = rue + "                             ", FontSize = 30 };

            StackLayout Layout8 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelCP = new Label
            {
                Text = " Code Postal : ",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 30
            };

            var MyEntryCP= new Entry { Text = "", Placeholder = codpost + "  ", FontSize = 30 };

            StackLayout Layout9 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelVILLE = new Label
            {
                Text = " Ville : ",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 30
            };

            var MyEntryVILLE = new Entry { Text = "", Placeholder = ville + "                          ", FontSize = 30 };
            
            StackLayout Layout10 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelMDP = new Label
            {
                Text = " Mot de passe : ",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 30
            };

            var MyEntryMDP = new Entry { Text = "", Placeholder = " ****************** ", FontSize = 30, IsPassword = true};
            Button boutonMDP = new Button()
            {
                Margin = new Thickness(1, 1, 1, 1),
                BackgroundColor = Color.FromHex("#27ae60"),
                BorderColor = Color.GhostWhite,
                BorderWidth = 2,
                CornerRadius = 10,
                Text = "Afficher",
                IsVisible = true,
                TextColor = Color.White,
            };
            boutonMDP.Clicked += Afficher;
            async void Afficher(object sender, EventArgs e)
            {
                if (MyEntryMDP.Placeholder ==  mdp)
                {
                    MyEntryMDP.Placeholder = " ****************** ";
                }
                else
                {
                    MyEntryMDP.Placeholder = mdp;
                }
            }

            StackLayout Layout11 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelROLE = new Label
            {
                Text = "  Votre role : ",
                FontSize = 30
            };
            var labelROLE2 = new Label
            {
                Text = rolelibelle,
                FontSize = 30
            };

            string classe = "";
            List<User> LeEleve = Database.MyCantineSQL.UnEleve(id);
            for (int i = 0; i < LeEleve.Count; i++)
            {
                User UnEleve = LeEleve[i];
                
                if (UnEleve.Classe != "")
                {
                    classe = UnEleve.Classe;
                }
                else
                {
                }
            }
            
            StackLayout Layout12 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(50, 0, 50, 20)
            };
            var labelCLASSE = new Label
            {
                Text = " Eleve de : ",
                FontSize = 30
            };
            var labelCLASSE2 = new Label
            {
                Text = classe,
                FontSize = 30
            };

            Layout1.Children.Add(labelNom);
            Layout1.Children.Add(labelNom2);

            Layout2.Children.Add(labelPrenom);
            Layout2.Children.Add(labelPrenom2);

            Layout4.Children.Add(labelTel);
            Layout4.Children.Add(MyEntryTel);

            Layout5.Children.Add(labelDateN);
            Layout5.Children.Add(MyEntryDateN);

            Layout6.Children.Add(labelEMAIL);
            Layout6.Children.Add(MyEntryEMAIL);

            Layout7.Children.Add(labelRUE);
            Layout7.Children.Add(MyEntryRue);
            
            Layout8.Children.Add(labelCP);
            Layout8.Children.Add(MyEntryCP);

            Layout9.Children.Add(labelVILLE);
            Layout9.Children.Add(MyEntryVILLE);

            Layout10.Children.Add(labelMDP);
            Layout10.Children.Add(MyEntryMDP);
            Layout10.Children.Add(boutonMDP);

            Layout11.Children.Add(labelROLE);
            Layout11.Children.Add(labelROLE2);

            Layout12.Children.Add(labelCLASSE);
            Layout12.Children.Add(labelCLASSE2);

            Button bouton = new Button()
            {
                Margin = new Thickness(220, 10, 220, 10),
                Padding = new Thickness(0, 10, 0, 10),
                BackgroundColor = Color.FromHex("#27ae60"),
                BorderColor = Color.GhostWhite,
                BorderWidth = 2,
                CornerRadius = 10,
                Text = "Validation",
                IsVisible = true,
                TextColor = Color.White,
            };
            bouton.Clicked += Validation;
            async void Validation(object sender, EventArgs e)
            {
               
                    if (MyEntryTel.Text != "" && MyEntryTel.Text.Length == 10)
                    {
                    Database.MyCantineSQL.setUnTelephone(MyEntryTel.Text, id);
                        if (MyEntryRue.Text != "" && MyEntryRue.Text != rue)
                        {
                            Database.MyCantineSQL.setUneRue(MyEntryRue.Text, id);
                            if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                            {
                                Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                                if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                                {
                                    Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                                    if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                                    {
                                    Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                                    Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                                    value = Application.Current.Properties["AppUser"];
                                    id = value.ToString();
                                }
                                }
                                if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                                {
                                Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                                Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                                value = Application.Current.Properties["AppUser"];
                                id = value.ToString();
                            }
                            }
                        }
                        if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                        {
                            Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                            if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                            {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            value = Application.Current.Properties["AppUser"];
                            id = value.ToString();
                            if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                            {
                                Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                            }
                            }
                        }
                        if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                        {
                            Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                            if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                            {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            value = Application.Current.Properties["AppUser"];
                            id = value.ToString();
                        }
                        }
                        if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                        {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                        value = Application.Current.Properties["AppUser"];
                        id = value.ToString();
                        if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                            {
                            Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                                if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                                {
                                Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                                
                                }
                            }

                        }
                    if (MyEntryRue.Text != "" && MyEntryRue.Text != rue)
                    {
                        Database.MyCantineSQL.setUneRue(MyEntryRue.Text, id);
                        if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                        {
                            Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                            if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                            {
                                Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                                {
                                    Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                                }
                            }
                            if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                            {
                                Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                                Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                                value = Application.Current.Properties["AppUser"];
                                id = value.ToString();
                                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                                {
                                    Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                                }
                            }
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }

                        if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                        {
                            Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                        {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            value = Application.Current.Properties["AppUser"];
                            id = value.ToString();
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                    {
                        Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                        if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                        {
                            Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                        if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                        {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            value = Application.Current.Properties["AppUser"];
                            id = value.ToString();
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                    {
                        Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                        if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                        {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            value = Application.Current.Properties["AppUser"];
                            id = value.ToString();
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                    {
                        Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                        Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                        value = Application.Current.Properties["AppUser"];
                        id = value.ToString();
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                    {
                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                    }
                }
                if (MyEntryTel.Text != "" && MyEntryTel.Text.Length == 10)
                {
                    Database.MyCantineSQL.setUnTelephone(MyEntryTel.Text, id);
                    if (MyEntryRue.Text != "" && MyEntryRue.Text != rue)
                    {
                        Database.MyCantineSQL.setUneRue(MyEntryRue.Text, id);
                        if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                        {
                            Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                            if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                            {
                                Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                                if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                                {
                                    Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                                    Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                                    value = Application.Current.Properties["AppUser"];
                                    id = value.ToString();
                                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                                    {
                                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                                    }
                                }
                                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                                {
                                    Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                                }
                            }
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                        {
                            Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                            if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                            {
                                Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                                Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                                value = Application.Current.Properties["AppUser"];
                                id = value.ToString();
                                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                                {
                                    Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                                }
                            }
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                    {
                        Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                        if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                        {
                            Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                            if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                            {
                                Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                                Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                                value = Application.Current.Properties["AppUser"];
                                id = value.ToString();
                                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                                {
                                    Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                                }
                            }
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                    {
                        Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                        if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                        {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                    {
                        Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                        Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                        value = Application.Current.Properties["AppUser"];
                        id = value.ToString();
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                    {
                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                    }
                }
                if (MyEntryRue.Text != "" && MyEntryRue.Text != rue)
                {
                    Database.MyCantineSQL.setUneRue(MyEntryRue.Text, id);
                    if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                    {
                        Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                        if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                        {
                            Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                            if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                            {
                                Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                                Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                                value = Application.Current.Properties["AppUser"];
                                id = value.ToString();
                                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                                {
                                    Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                                }
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                    {
                        Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                        if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                        {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            value = Application.Current.Properties["AppUser"];
                            id = value.ToString();
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                    {
                        Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                        Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                        value = Application.Current.Properties["AppUser"];
                        id = value.ToString();
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                    {
                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                    }
                }
                if (MyEntryCP.Text != "" && MyEntryCP.Text != codpost)
                {
                    Database.MyCantineSQL.setUnCodePost(MyEntryCP.Text, id);
                    if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                    {
                        Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                        if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                        {
                            Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                            Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                            value = Application.Current.Properties["AppUser"];
                            id = value.ToString();
                            if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                            {
                                Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                            }
                        }
                    }
                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                    {
                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                    }
                }
                if (MyEntryVILLE.Text != "" && MyEntryVILLE.Text != ville)
                {
                    Database.MyCantineSQL.setUneVille(MyEntryVILLE.Text, id);
                    if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                    {
                        Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                        Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                        value = Application.Current.Properties["AppUser"];
                        id = value.ToString();
                        if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                        {
                            Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                        }
                    }
                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                    {
                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                    }
                }

                if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                {
                    Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                    Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                    value = Application.Current.Properties["AppUser"];
                    id = value.ToString();
                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                    {
                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                    }
                }
                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != id)
                {
                    Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                }
                 if (MyEntryEMAIL.Text != "" && MyEntryEMAIL.Text != id)
                 {
                     Database.MyCantineSQL.setUnEmail(MyEntryEMAIL.Text, id);
                     Application.Current.Properties["AppUser"] = MyEntryEMAIL.Text;
                     value = Application.Current.Properties["AppUser"];
                     id = value.ToString();
                    if (MyEntryMDP.Text != "" && MyEntryMDP.Text != mdp)
                    {
                        Database.MyCantineSQL.setUnMDP(MyEntryMDP.Text, id);
                    }
                }
                    await Navigation.PushAsync(new UserProfil());
            }

            if (classe != "") { 
                this.Content = new StackLayout
            {
                Children =
                {
                    Layout1,
                    Layout2,
                    Layout4,
                    Layout5,
                    Layout6,
                    Layout7,
                    Layout8,
                    Layout9,
                    Layout10,
                    Layout12,
                    bouton

                }
            };
            }
            else
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    Layout1,
                    Layout2,
                    Layout4,
                    Layout5,
                    Layout6,
                    Layout7,
                    Layout8,
                    Layout9,
                    Layout10,
                    bouton

                }
                };
            }
        }
    }
}