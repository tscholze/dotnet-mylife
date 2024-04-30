﻿using MyLife.Core.Models;
using MyLife.Core.Models.Coding;
using MyLife.Core.Models.CV;
using MyLife.Core.Models.Shared;

namespace MyLife.Core.Generator
{
    /// <summary>
    /// Provides methods to generate sample life objects.
    /// </summary>
    public static class SampleGenerators
    {
        #region Public generators

        /// <summary>
        /// Generates a sample life object.
        /// </summary>
        /// <returns>Sample life object</returns>
        public static Life GenerateLife()
        {
            return new Life
            {
                LastUpdated = DateTimeOffset.Now,
                Version = "0.1.0",
                Language = "en",
                Persona = GeneratePersona(),
                CurriculumVitae = GenerateCurriculumVitae(),
                OpenSource = GenerateOpenSource(),
                SocialMedia = GenerateSocialMedia(),
                ContentCreation = GenerateContentCreation(),
            };
        }

        #endregion

        #region Private generators
        private static Persona GeneratePersona()
        {
            return new Persona
            {
                Firstname = "Tobias",
                Lastname = "Scholze",
                Nicknames = [
                    "The Stuttering Nerd",
                    "Tobonaut"
                    ],
                LocationPath = [
                    "Germany",
                    "Bavaria",
                    "Augsburg"
                    ],
                AvatarImageUrls = [
                    "https://tscholze.github.io/content-tslifekit/files/avatar-1-min.jpeg"
                    ],
                Languages = [
                    "German", 
                    "English"
                    ],
                YearOfBirth = 1988,
                IntroductionParagraphs = [
                    "Nice to have you here!",
                    "I am Tobias from beautiful Bavaria and I am a software engineer, nerd and hobby content creator with heart and soul to inspire people for programming as well as to educate about stuttering and multiple sclerosis.",
                    "On my site you will find a small overview of everything I do in terms of open source development, my articles for Dr. Windows and on Medium, videos and all other experiments I fabricate in my spare time like podcasting.",
                    "Have fun!",
                    ],
                AcademicTitle = "Bachelor of Science"
            };
        }

        internal static CurriculumVitae GenerateCurriculumVitae()
        {
            var anfema = new Employment
            {
                Company = "anfema GmbH",
                Role = "Senior Software Engineer for iOS",
                Tasks = [
                    "Planning, development and maintanance of B2B grade for iOS and iPadOS with focus on HR and industriy 4.0",
                    "Helping customers to understand how apps can transform their work life",
                    "Onboarding of new team members",
                    "Planning and management of multi-division tasks"
                    ],
                Joined = "11-2015",
                Left = null
            };

            return new CurriculumVitae
            {
                CurrentEmployment = anfema,
                RecentEmployments = [
                    anfema,
                    new Employment
                    {
                        Company = "NCR Deutschland GmbH",
                        Role = "Java Software Engineer",
                        Tasks = [
                            "Maintanance of a management platform for ATMs in the GSA (DACH) region",
                            "Creating concepts on how to modernise the user expierence of the platform"
                        ],
                        Joined = "04-2015",
                        Left = "10-2015"
                    },
                    new Employment
                    {
                        Company = "Media Decision GmbH",
                        Role = "Java / C# Software Engineer",
                        Tasks = [
                            "Planning and development of an ad real time bidding system written in Java EE and JSF",
                            "Developing a ad platform agnostic analytic tool for performance marketing KPIs in C# and Silverlight"
                        ],
                        Joined = "04-2013",
                        Left = "03-2015"
                    }
                ],
                Educations = [
                    new Education
                    {
                        Instituation = "University of Applied Sciene Augsburg",
                        Content =  [
                            "Specialization in computer science with a focus on applied software development",
                            "Practical project work, including in cooperation with the Fraunhofer Institute to prevent cross-contamination in food logistics",
                            "International project to reduce energy consumption in private households using a software solution that is compatible with many standards"
                            ],
                        Graduation = "Bachelor of Science",
                        YearOfGraduation = 2013
                    },
                    new Education
                    {
                        Instituation = "Städtische Berufoberschule Augsburg",
                        Content = [
                            "Second-chance education specializing in mathematics and physics"
                            ],
                        Graduation = "High school diplom",
                        YearOfGraduation = 2009
                    },
                    new Education {
                        Instituation = "BFS Rudolf Diesel Augsburg",
                        Content = [
                            "Vocational training as a technical assistant for computer science",
                            "Training in software development as well as networking and electronics"
                            ],
                        Graduation = "State-certified TACS (IHK)",
                        YearOfGraduation = 2008
                    }
                ],
                Publications = [
                    new Publication
                    {
                        Title = "Das dynamische Mindesthaltbarkeitsdatum - Auf dem Weg zu einer Echtzeitereignisverarbeitung in der Lebensmittellogistik",
                        Publisher = "DSEP",
                        Year = 2013
                    }
                ],
                Skillset = new Skillset
                {
                    ProgrammingLanguages = [
                        "Swift",
                        "C#",
                        "Kotlin",
                        "Java"
                    ],
                    ProductLifecycleTooling = [
                        "GitHub product family",
                        "Atlassian product family",
                        "Azure DevOps"
                    ],
                    DevelopmentEnvironments = [
                        "Xcode",
                        "JetBrains product family",
                        "Visual Studio",
                        "Visual Studio Code"
                    ],
                    DesignEnvironments = [
                        "Figma",
                        "Sketch",
                        "Zepelin"
                    ],
                    DesignGuidelines = [
                        "Apple Human Interface Guide",
                        "Android Material Design Principals"
                    ],
                    SoftSkills = [
                        "Take ownership of your work",
                        "Embraces change and stay open to learning new technologies",
                        "Collaborates effectively with engineers, stakeholders, and team members",
                        "Good in creating a team spirit"
                    ]
                },
                Activities = [
                    "Content creation covering my stuttering and my multiple sclerosis",
                    "Writing articles for one of the biggest German speaking Microsoft sites Dr. Windows",
                    "Tinkering with Raspberry Pis and new technologies",
                    "Trying to close my Apple Watch rings"
                ],
                OtherInterests = [
                    "Free and Open Source",
                    "Feeling the sound of music",
                    "Tasting the word locally",
                    "Panda bears"
                ]
            };
        }

        internal static OpenSource GenerateOpenSource()
        {
            return new OpenSource
            {
                TagLine = "Tobias Scholze, Senior Software Engineer for Enterprise-grade mobile applications, community enthusiast",
                Motivation = "I want to spark the joy of software engineering in everyone who is intereset in computer sciene. That's my motication to create simple but educational open source projects to provide an entry in this world of fun.",
                GitHubUsername = "tscholze",
                GitHubUrl = new("https://github.com/tscholze"),
                ProjectFamilies = [
                    new ProjectFamily
                    {
                        Name = "Kpi - Kotlin/Native <3 Raspberry Pi",
                        Description = "Using Kotlin/Native with C-Bindings on a Raspberry Pi to work with some Pimoroni boards",
                        ImageUrl = new("https://tscholze.github.io/blog/files/pf-kpi-logo.png"),
                        Projects = [
                            new Project {
                                Name = "KPi.Enviro",
                                Descripton = "Reading values from a BMP280 and TC3472 sensor in addition to controlling some LEDs",
                                GithubUrl = new("https://github.com//tscholze/kotlin-kpi-native-enviro"),
                                ImageUrl = new("https://github.com/tscholze/kotlin-kpi-native-enviro/blob/main/__docs/socialmedia.png"),
                                ProgrammingLanguage = "kotlin"
                            },
                            new Project {
                                Name = "KPi.Blinkt",
                                Descripton = "Web- and curl-interface to let a Pimoroni Blinkt HAT shine, morse and do other things",
                                GithubUrl = new("https://github.com//tscholze/kotlin-kpi-native-enviro"),
                                ImageUrl = new("https://raw.githubusercontent.com/tscholze/kotlin-kpi-native-blinkt/main/_docs/socialmedia.png"),
                                ProgrammingLanguage = "kotlin"
                            }
                        ]
                    },
                    new ProjectFamily
                    {
                        Name =  "HomeBear - Windows 10 + Pi + Pimoroni = <3",
                        Description = "Windows 10 IoT Core meets C# and .NET, Raspberry Pi, meets Pimoroni HATs",
                        ImageUrl = new("https://tscholze.github.io/blog/files/pf-hb-logo.png"),
                        Projects = [
                            new Project {
                                Name = "HomeBear.Tilt",
                                Descripton = "Using a robot tilting arm to have a camera that detects your faces? This UWP provides such PoC functionality. All running on a Raspberry Pi.",
                                GithubUrl = new("https://github.com/tscholze/dotnet-iot-homebear-tilt"),
                                ImageUrl = new("https://github.com/tscholze/dotnet-iot-homebear-tilt/raw/master/docs/on-device-screenshot.jpg"),
                                ProgrammingLanguage = "csharp"
                            },
                            new Project {
                                Name = "HomeBear.Rainbow",
                                Descripton = "Controlling a Pimoroni RainbowHAT using Windows 10 IoT Core and C#",
                                GithubUrl = new("https://github.com/tscholze/dotnet-iot-homebear-rainbow"),
                                ImageUrl = new("https://github.com/tscholze/blog/blob/main/docs/files/pf-hb-rainbow.png?raw=true"),
                                ProgrammingLanguage = "csharp"
                            },
                            new Project {
                                Name = "HomeBear.Blinkt",
                                Descripton = "An IoT app that provides an on-device UI for controlling multiple aspects of a Pimoroni BlinktHAT",
                                GithubUrl = new("https://github.com/tscholze/dotnet-iot-homebear-blinkt"),
                                ImageUrl = new("https://github.com/tscholze/blog/blob/main/docs/files/pf-hb-blinkt.png?raw=true"),
                                ProgrammingLanguage = "csharp"
                            }
                        ]
                    },
                    new ProjectFamily
                    {
                        Name =  "Surface Duo shenanigans",
                        Description = "Two separate screens on a single device? Yes, the Duo was a great device",
                        ImageUrl = new("https://tscholze.github.io/blog/files/pf-duo-logo.png"),
                        Projects = [
                            new Project {
                                Name = "Road To Surface Duo",
                                Descripton = "In anticipation of the release of the Microsoft Surface Duo, I wrote for Dr. Windows wrote a multi-part series of articles that should make you want to develop for the device",
                                GithubUrl = new ("https://github.com/tscholze/xamarin-road-to-surface-duo"),
                                ImageUrl = new("https://github.com/tscholze/xamarin-road-to-surface-duo/raw/master/docs/ui-app-duo.jpg"),
                                ProgrammingLanguage = "csharp"
                            },
                            new Project {
                                Name = "RssBook",
                                Descripton = "A RSS reader in a book-ish design that uses both screens of the Surface Duo",
                                GithubUrl = new("https://github.com/tscholze/flutter-surfaceduo-rssbook"),
                                ImageUrl = new("https://github.com/tscholze/flutter-surfaceduo-rssbook/raw/main/docs/screenshots-ds.png?raw=true"),
                                ProgrammingLanguage = "flutter"
                            },
                            new Project {
                                Name = "Hinge It!",
                                Descripton = "A gamification app that uses the hinge of the Duo to guess it's angle.",
                                GithubUrl = new("https://github.com/tscholze/xamarin-surface-duo-hinge-it"),
                                ImageUrl = new ("https://github.com/tscholze/xamarin-surface-duo-hinge-it/blob/master/docs/summary.png?raw=true"),
                                ProgrammingLanguage = "csharp"
                            },
                            new Project {
                                Name = "DuoBahn",
                                Descripton = "An app that shows you all kind of information around German Autobahn information and webcams. Cancelled due to shut down webcams because of Ukrainian war",
                                GithubUrl = new("https://github.com/tscholze/kotlin-surfaceduo-duobahn"),
                                ImageUrl = new("https://www.drwindows.de/news/wp-content/uploads/2022/08/duo_bahn_app.png"),
                                ProgrammingLanguage = "csharp"
                            }
                        ]
                    },
                    new ProjectFamily {
                        Name = "Android Things Tinkerings",
                        Description = "Google Android Things on a Raspberry Pi was a very fun time and I tinkered some apps that uses Pimoroni Hardware",
                        ImageUrl = new("https://github.com/tscholze/blog/blob/main/docs/files/pf-at-logo"),
                        Projects = [
                            new Project {
                                Name = "ToboT",
                                Descripton = "Control a Pimoroni STS Pi vehicle via a web interface and your voice. Everything is based on an Android Things app that runs on a Raspberry Pi",
                                ImageUrl = new("https://tscholze.github.io/blog/assets/java-android-tobot-5.png"),
                                GithubUrl = new("https://github.com/tscholze/java-android-things-tobot"),
                                ProgrammingLanguage = "java"
                            },
                            new Project {
                                Name = "Things Pager",
                                Descripton = "Show your Firebase messages on a 8-segment display using a Raspberry Pi",
                                ImageUrl = new("https://github.com/tscholze/java-android-things-firebase-pager/raw/master/docs/scheme.png"),
                                GithubUrl = new("https://github.com/tscholze/java-android-things-firebase-pager"),
                                ProgrammingLanguage = "java"
                            }
                        ]
                    },
                    new ProjectFamily {
                        Name = "Python wrangling",
                        Description = "Sometimes I need to use the snake to catch some fun",
                        ImageUrl = new("https://github.com/tscholze/blog/blob/main/docs/files/pf-python-raspberry-logo.png"),
                        Projects = [
                            new Project {
                                Name = "Enviro HAT to Excel Online logger",
                                Descripton = "Uses the Pimoroni EnviroHAT to log specific values via Microsoft Graph API to an Online Excel Sheet document",
                                GithubUrl = new("https://github.com/tscholze/python-enviro-excel-online-logger"),
                                ImageUrl = new("https://github.com/tscholze/python-enviro-excel-online-logger/blob/master/docs/dashboard.PNG?raw=true"),
                                ProgrammingLanguage = "python"
                            },
                            new Project {
                                Name = "Enviro HAT to Google Drive Sheets logger",
                                Descripton = "Uses the Pimoroni Enviro HAT to log specific values to a Google Drive Sheets document",
                                GithubUrl = new ("https://github.com/tscholze/python-enviro-gdocs-logger"),
                                ImageUrl = new("https://raw.githubusercontent.com/tscholze/python-enviro-gdocs-logger/master/docs/dashboard.png"),
                                ProgrammingLanguage = "python"
                            }
                        ]
                    }
                ]
            };
        }

        internal static SocialMedia[] GenerateSocialMedia()
        {
            return [
                new SocialMedia {
                    Username = "Tobias Scholze",
                    Platform = Platform.Linkedin,
                    Url = new("https://linkedin.com/in/tobias-scholze-4301b518")
                },
                new SocialMedia {
                    Username = "@tscholze",
                    Platform = Platform.GitHub,
                    Url = new("https://github.com/tscholze")
                },
                new SocialMedia {
                    Username = "@tobonaut",
                    Platform = Platform.Twitter,
                    Url = new("https://twitter.com/tobonaut")
                },
                new SocialMedia {
                    Username = "@tobonaut",
                    Platform = Platform.Mastodon,
                    Url = new("https://mastodon.social/@tobonaut")
                }
            ];
        }

        internal static ContentCreation[] GenerateContentCreation()
        {
            return [
                new ContentCreation {
                    Name = "Tobias Scholze - The Stuttering Nerd",
                    Description = "From the life of a stuttering nerd with multiple sclerosis",
                    Platform = Platform.Youtube,
                    Language = Language.German,
                    Url = new ("https://www.youtube.com/user/TobiasScholze")
                },
                new ContentCreation {
                    Name = "The Stuttering Nerd",
                    Description = "Education about the topics of stuttering, multiple sclerosis and nerdiness",
                    Platform = Platform.Tiktok,
                    Language = Language.German,
                    Url = new("https://www.tiktok.com/@the_stuttering_nerd")
                },
                new ContentCreation {
                    Name = "@the_stuttering_nerd",
                    Description = "Things from the everyday life of a nerd who stutters with multiple sclerosis.",
                    Platform = Platform.Instagram,
                    Language = Language.German,
                    Url = new("https://www.instagram.com/the_stuttering_nerd/")
                },
                new ContentCreation {
                    Name = "La-La-Laber doch! Der Stotter Podcast",
                    Description = "In this podcast experiment I would like to pull myself out of my comfort zone and dare to do something that I have always shied away from. I speak - in public and even in front of people who are unfamiliar with the picture",
                    Platform = Platform.Podcast,
                    Language = Language.German,
                    Url = new("https://tscholze.github.io/podcast-la-la-laber-doch"),

                },
                new ContentCreation {
                    Name = "Dr. Window",
                    Description = "I write articles about the fun of IT and its tinkering on one of the largest German-language Microsoft sites.",
                    Platform = Platform.News,
                    Language = Language.German,
                    Url = new("https://www.drwindows.de/news/author/tobias")
                },
                new ContentCreation {
                    Name = "DualScreen Tobbo",
                    Description = "My toughts on playing around with the Microsoft Surface and its SDKs and showing the joy tinkering with this new device category",
                    Platform = Platform.Medium,
                    Language = Language.English,
                    Url = new("https://dualscreentobbo.medium.com")
                },
                new ContentCreation {
                    Name = "DevRel Tobbo",
                    Description = "It's my kind of role play in which I pretend I'm a DevRel engineer for various software development topics.",
                    Platform = Platform.Medium,
                    Language = Language.German,
                    Url = new("https://devreltobbo.medium.com")
                },
                new ContentCreation {
                    Name = "Personal blog",
                    Description = "My blog stores articles about things I made, I expierenced and all other information I do not want to forget",
                    Platform = Platform.Blog,
                    Language = Language.EnglishAndGerman,
                    Url = new("https://tscholze.github.io/blog/")
                }
            ];
        }

        #endregion
    }
}