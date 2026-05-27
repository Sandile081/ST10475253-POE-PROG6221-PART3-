using Microsoft.VisualBasic;
using System.Speech.Synthesis;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CybersecuirtyChatbotUI
{
   
    public partial class MainWindow : Window
    {
        public static String name=" ";
        public static String Info = "";
        public static List<String> conversationHistory = new List<String>();

        public MainWindow()
        {
            InitializeComponent();
            
//calling the voice method when the content is rendered
            this.ContentRendered += voiceCalling;
        }
//method to call the voice when the content is rendered
        private void voiceCalling(object sender, EventArgs e)
        {
//creating an instance of the speech synthesizer class to use the speak method
            SpeechSynthesizer ChatbotVoice = new SpeechSynthesizer();
            ChatbotVoice.Speak("hello welcome to the cybersecurity awareness bot.");
            ChatbotVoice.Speak("I'm here to help you to stay safe online. what is your name?");
        }
//method to send the request when the user clicks the send button
        public void sendrequest(object sender, RoutedEventArgs e)
        {
//creating an instance of the speech synthesizer class to use the speak method

            SpeechSynthesizer voice = new SpeechSynthesizer();
            Border TextAppearence = new Border();
            TextBlock input = new TextBlock();

//taking the user input and converting it to lowercase and trimming the spaces
            input.Text = message.Text.ToLower().Trim();


 //setting the properties of the user input textblock and the border around it to make it look like a chat bubble
            input.HorizontalAlignment = HorizontalAlignment.Right;
            input.FontSize = 16;
            input.Background = Brushes.Transparent;
            input.Foreground = Brushes.Blue;
            input.Width = 400;

 //setting the properties of the border around the user input to make it look like a chat bubble
            TextAppearence.Background = Brushes.SkyBlue;
            TextAppearence.CornerRadius = new CornerRadius(7);
            TextAppearence.Width = 400;
            TextAppearence.Height = Double.NaN;
            TextAppearence.HorizontalAlignment = HorizontalAlignment.Right;
            TextAppearence.BorderBrush = new SolidColorBrush(Colors.Transparent);
            TextAppearence.BorderBrush = new SolidColorBrush(Colors.Transparent);
            TextAppearence.Child = input;

  //adding the user input to the stack panel to display it in the chat window
            displaying.Children.Add(TextAppearence);

            
            Border ChatBotTextAppearence = new Border();
            TextBlock output = new TextBlock();
//checking the user input for specific keywords and responding accordingly
            if (input.Text.Contains("my name is"))
            {
 //taking the name from the user input and converting it to uppercase
                name = input.Text.Substring(11).ToUpper();
                output.Text = "Nice to meet you " + name
                              + ".\n How can I help you " + name;
            }
 //checking if the user input contains bye or goodbye and responding accordingly
            else if (input.Text.Contains("bye") || input.Text.Contains("goodbye"))
            {
                MessageBox.Show("Goodbye " + name + " it was nice talking to you.");
                Environment.Exit(0);
            }
//checking if the user input contains summary or summarize or preview or review or overview or previous conversation or remind me and responding accordingly
            else if (input.Text.Contains("summary") || input.Text.Contains("summarize") || input.Text.Contains("preview") || input.Text.Contains("review") || input.Text.Contains("overview") || input.Text.Contains("previous conversation") || input.Text.Contains("remind me"))
            {
                output.Text = Summary();
            }
//checking if the user input contains tell me more or give me more or explain and responding accordingly
            else if (input.Text.Contains("tell me more") || input.Text.Contains("give me more") || input.Text.Contains("explain"))
            {
                output.Text = Explaination(Info);
                conversationHistory.Add(output.Text);
            }
//checking if the user input contains what is and responding accordingly
            else if (input.Text.Contains("what is"))
            {
                output.Text = Defination(input.Text, name);
                conversationHistory.Add(output.Text);
            }
//checking if the user input contains tip or tips and responding accordingly
            else if (input.Text.Contains("tip") || input.Text.Contains("tips"))
            {
                output.Text = TipsMethod(input.Text);
                conversationHistory.Add(output.Text);
            }
//if the user input does not contain any of the above keywords then it will respond with the general response method
            else
            {
                output.Text = RespondSystem(input.Text, name);
                conversationHistory.Add(output.Text);
            }


            output.HorizontalAlignment = HorizontalAlignment.Left;
            output.FontSize = 16;
            output.Background = Brushes.Transparent;
            output.Foreground = Brushes.Green;
            output.Width = 400;
            output.Height = Double.NaN;
            output.TextWrapping=TextWrapping.Wrap;
            output.MinHeight = 30;
            output.MaxHeight= 400;

            ChatBotTextAppearence.Background = Brushes.Cyan;
            ChatBotTextAppearence.CornerRadius = new CornerRadius(7);
            ChatBotTextAppearence.Width = 410;
            ChatBotTextAppearence.Height = Double.NaN;
            ChatBotTextAppearence.HorizontalAlignment = HorizontalAlignment.Left;
            ChatBotTextAppearence.BorderThickness = new Thickness(7);
            ChatBotTextAppearence.BorderBrush= new SolidColorBrush(Colors.Transparent);
            ChatBotTextAppearence.Child = output;

          

            displaying.Children.Add(ChatBotTextAppearence);

            message.Text = "";


        }
        public String Summary()
        {
            String summary = "";
            foreach (String conversation in conversationHistory)
            {
                summary += conversation + "\n";
            }
            return summary;

        }

        static String RespondSystem(string interactor, string name)
        {
            string respond = " ";
            

            Dictionary<string, string> memory = new Dictionary<string, string>()
            {
            // General Cybersecurity questions

               {"how are you","I'm good. Thanks for asking. How can i help you?"},


               {"hey","Hello!! Welcome to the Cybersecurity Awareness Bot. how cam i help you"},

               {"hello","Hello!! Welcome to the Cybersecurity Awareness Bot. how cam i help you"},


               {"cybersecurity","Cybersecurity is the practice of protecting systems, networks, and data from digital attacks."},

               {"password","A password is a secret word or phrase used to access an account or system."},

               {"phishing","Phishing is a scam where attackers trick users into giving sensitive information."},

               {"malware","Malware is harmful software designed to damage or access systems without permission."},

               {"ransomware","Ransomware is malware that locks files and demands payment to unlock them."},

               {"virus","A virus is a type of malware that spreads by attaching itself to files."},

               {"worm","A worm is malware that spreads automatically through networks."},

               {"trojan","A Trojan is malware disguised as legitimate software."},

               {"firewall","A firewall is a system that blocks unauthorized access to or from a network."},

               {"encryption","Encryption is the process of converting data into a secure code."},

               {"decryption","Decryption is converting encrypted data back into readable form."},

               {"authentication","Authentication is the process of verifying a user's identity."},

               {"authorization","Authorization determines what a user is allowed to access."},

               {"multi factor authentication?","It is a security process that requires multiple methods to verify identity."},

               {"two factor authentication","It is a type of authentication using two verification methods."},

               {"data breach","A data breach is when sensitive information is accessed without permission."},

               {"hacker","A hacker is a person who gains unauthorized access to systems."},

               {"ethical hacking","Ethical hacking is legal hacking used to find and fix security weaknesses."},

               {"spyware","Spyware is malware that secretly collects user information."},

               {"adware","Adware is software that displays unwanted advertisements."},

               {"keylogger","A keylogger records keystrokes to capture sensitive information."},

               {"botnet","A botnet is a network of infected computers controlled by an attacker."},

               {"ddos attack","A DDoS attack overwhelms a system with traffic to make it unavailable."},

               {"vpn","A VPN is a secure connection that protects your internet activity."},

               {"https","HTTPS is a secure version of HTTP that encrypts web traffic."},

               {"http","HTTP is a protocol used to transfer data over the internet."},

               {"secure website","A secure website uses encryption to protect user data."},

               {"identity theft","Identity theft is stealing personal information for fraud."},

               {"social engineering","Social engineering tricks people into revealing confidential information."},

               {"cyberattack","A cyberattack is an attempt to damage or access systems illegally."},

               {"cyber threat","A cyber threat is a potential danger to systems or data."},

               {"antivirus","Antivirus software detects and removes malicious programs."},

               {"software update","A software update fixes bugs and security vulnerabilities."},

               {"backup","A backup is a copy of data stored for recovery."},

               {"cloud security","Cloud security protects data stored online."},

               {"network security","Network security protects computer networks from threats."},

               {"information security","Information security protects all forms of data."},

               {"public wi-fi","Public Wi-Fi is a shared internet connection that may be insecure."},

               {"private network","A private network is restricted and secure from public access."},

               {"router","A router directs internet traffic between devices."},

               {"ip address","An IP address identifies a device on a network."},

               {"domain name","A domain name is the address of a website."},

               {"spam","Spam is unwanted or harmful messages sent online."},

               {"scam","A scam is a fraudulent scheme to steal money or information."},

               {"cybercrime","Cybercrime is illegal activity done using computers or the internet."},

               {"digital footprint","A digital footprint is the data you leave behind online."},

               {"privacy","Privacy is the protection of personal information."},

               {"security policy","A security policy is a set of rules to protect systems and data."},

               {"incident response","Incident response is how organizations handle cyberattacks."},

               {"risk management","Risk management is identifying and reducing cybersecurity risks."},

               {"strong password","Use at least 12 characters including letters, numbers, and symbols." },

               {"password manager","A password manager securely stores and generates strong passwords." },

               {"weak password","Short passwords, common words, or personal information make passwords weak." },

                {"my name","Your name is " + name + ". I've never heard that name before but it's abolutely unique!"},
                //Tips for each cybersecurity topics
            
              // Additional question that might be asked

               {"what is your purpose","The chatbot teaches users about cyber threats such as phishing, malware, hacking, and identity theft. It also encourages good cybersecurity practices like strong passwords and avoiding suspicious links."},

               {"purpose","The chatbot teaches users about cyber threats such as phishing, malware, hacking, and identity theft. It also encourages good cybersecurity practices like strong passwords and avoiding suspicious links."},

               {"what can i ask you about","You can ask me general cybersecurity questions and how to stay safe online."},

               {"about","You can ask me general cybersecurity questions and how to stay safe online."},

               {"what is cybersecurity","Cybersecurity is the practice of protecting computers, networks, systems, and data from cyberattacks and unauthorized access."},

               {"why is cybersecurity important","Cybersecurity protects personal information, financial data, and business systems from being stolen or damaged."},

               {"important","Cybersecurity protects personal information, financial data, and business systems from being stolen or damaged." },

               {"what are the most common cyber threats today","Common cyber threats include phishing, malware, ransomware, identity theft, and social engineering attacks."},

               {"how can i protect my personal information online","Use strong passwords, enable two-factor authentication, avoid suspicious links, and only share information on trusted websites."},

               {"what is the difference between cybersecurity and information security","Cybersecurity protects digital systems and networks, while information security protects all types of information."},

               {"what is a cyberattack","A cyberattack is an attempt to access, damage, or steal data from a computer system or network."},

              {"who are hackers and what do they do","Hackers try to gain unauthorized access to computer systems. Some are criminals while others help organizations find security weaknesses."},

              {"what are the basic principles of cybersecurity","The main principles are confidentiality, integrity, and availability of data."},

              {"how do companies protect their data from cyber threats","Companies use firewalls, encryption, antivirus software, security policies, and employee training."},

              {"what are the biggest cybersecurity risks for individuals","Weak passwords, phishing emails, unsafe downloads, and unsecured public Wi-Fi."},


                 // Password and Authentication

              {"how do i create a strong password","Use at least 12 characters including letters, numbers, and symbols."},

              {"why should i avoid using the same password for multiple accounts","If one account gets hacked, attackers may access your other accounts."},

              {"what is multi factor authentication","It requires more than one way to verify your identity, like a password and a code sent to your phone."},

              {"why is two factor authentication important","It adds an extra layer of security and makes hacking more difficult."},

              {"how often should i change my password","You should change important passwords every 3 to 6 months."},

              {"what is a password manager","A password manager securely stores and generates strong passwords."},

              {"is it safe to store passwords in my browser","It can be convenient but a dedicated password manager is usually safer."},

              {"what makes a password weak","Short passwords, common words, or personal information make passwords weak."},

              {"what should i do if my password is hacked","Change it immediately and enable two-factor authentication."},

              {"how can i remember strong passwords","Use passphrases or store them in a password manager."},



    // Phishing

              {"what is phishing","Phishing is a scam used to trick people into revealing sensitive information."},

              {"how can i identify a phishing email","Look for suspicious links, unknown senders, poor grammar, or urgent requests."},

              {"what should i do if i receive a suspicious email","Do not click links or attachments. Delete or report the email."},

              {"can phishing happen through sms messages","Yes, it is called smishing."},

              {"what is spear phishing","A targeted phishing attack aimed at a specific person or organization."},

              {"how do hackers use phishing to steal information","They send fake emails or create fake websites to trick users."},

             {"what is a fake website and how can i identify one","Check the website address, spelling, and if it uses HTTPS."},

             {"what should i do if i accidentally click a phishing link","Close the page and scan your device with antivirus software."},



    // Malware

             {"what is malware","Malware is malicious software designed to harm or access systems without permission."},

             {"what is the difference between a virus worm and trojan","A virus spreads through files, a worm spreads through networks, and a Trojan hides inside legitimate software."},

             {"how can malware infect my computer","Through infected downloads, email attachments, or unsafe websites."},

             {"what is ransomware","Ransomware locks your files and demands payment to unlock them."},

             {"what should i do if my computer gets infected with malware","Disconnect from the internet and run antivirus software."},

             {"how can antivirus software protect my device","It scans and removes malicious programs."},

             {"can smartphones get viruses","Yes, especially from unsafe apps or downloads."},

             {"how can i safely download files from the internet","Download only from trusted websites."},



    // Internet Safety

             {"is public wi-fi safe to use","Public Wi-Fi can be risky. Avoid accessing sensitive accounts."},

             {"how can i stay safe on social media","Use privacy settings and avoid sharing personal information."},

             {"what personal information should i avoid sharing online","Avoid sharing addresses, ID numbers, passwords, or bank details."},

             {"how can hackers use social media to attack people","They gather personal information for scams or phishing."},

             {"what are privacy settings and why are they important","They control who can see your information online."},

             {"how can i protect my identity online","Use strong passwords and limit personal information sharing."},



    // Device Security

             {"how can i secure my home wifi network","Use a strong password and change the router default password."},

             {"why should i update my software regularly","Updates fix security vulnerabilities."},

             {"what is a firewall","A firewall monitors network traffic and blocks threats."},

             {"how do i know if my device has been hacked","Signs include slow performance, unknown apps, or strange pop-ups."},

             {"what should i do if my phone is stolen","Lock the device remotely and report it to your service provider."},

             {"how can i protect my laptop when using it in public","Avoid public Wi-Fi and lock your device when not using it."},



    // Best Practices

             {"what are the best cybersecurity habits everyone should follow","Use strong passwords, update software, and avoid suspicious links."},

             {"what should i do if i become a victim of a cyberattack","Change passwords, scan devices, and report the incident."},

             {"what is identity theft","Identity theft is when someone uses your personal information without permission."},

             {"how can i avoid identity theft","Protect your personal information and use strong passwords."},

             {"what is a secure website","A secure website uses HTTPS encryption."},

             {"what does https mean","HTTPS means HyperText Transfer Protocol Secure."},

             {"what should i do if i click a suspicious link","Close it and run antivirus software."},

             {"what is social engineering","A technique used to manipulate people into revealing confidential information."},

             {"why should i lock my computer","It prevents unauthorized access to your data."},

             {"what is a vpn","A VPN protects your internet connection and privacy."},

             {"is it safe to download free software","Only download from trusted websites."},

             {"what is a data breach","A data breach happens when sensitive information is stolen."},

             {"how do i know if a website is fake","Check the URL, spelling, and HTTPS."},

             {"what is encryption","Encryption converts data into secure code."},

             {"why is cybersecurity awareness important","It helps people recognize cyber threats."},

             {"what is spyware","Spyware secretly collects information without permission."},

             {"why should i back up my data","Backups protect files from loss or malware."},

             {"what is a cyber threat","Any activity that can harm systems or data."},

             {"how can i protect my wifi network","Use a strong password and encryption."},

             {"what is cybercrime","Illegal activity done using computers or the internet."},

             {"how can i stay safe when shopping online","Use trusted websites and secure payment methods."}
};

            foreach(String keyword in memory.Keys)
            {
                if (interactor.Contains(keyword))
                {
                    respond = memory[keyword];
                    Info = keyword;
                    break;
                }
                else
                {
                    respond = "Sorry I don't understand that. Please ask me a general cybersecurity question or how to stay safe online.";
                }
            }

            return respond;
        }
        public String TipsMethod(String Tips)
        {
            String TipRespond = "";
            Dictionary<string, string> TipsMemory = new Dictionary<string, string>()
            {
                { "phishing tip", "Never click links in unexpected emails. Hover over links to see the real URL. When in doubt, contact the sender directly by phone to verify." },
               
                { "phishing email tip", "Look for red flags: poor grammar, urgent requests, mismatched email addresses, and suspicious attachments." },

// Password tips
             
                { "password tip", "Create strong passwords with at least 12 characters, mixing uppercase, lowercase, numbers, and symbols. Never reuse passwords!" },
             
                { "strong password tip", "Use passphrases like 'PurpleElephant$JumpsOver3Times!' - they're long, memorable, and hard to crack." },
               
                { "password manager tip", "Use a password manager like Bitwarden, LastPass, or 1Password to generate and store unique passwords securely." },

// Cybersecurity tips
                { "cybersecurity tip", "Enable 2FA everywhere possible, keep software updated, use antivirus, and think before you click!" },
              
                { "general security tip", "Always lock your computer when stepping away, even at home. Use a screensaver with password protection." },

// Malware tips
              { "malware tip", "Don't download software from untrusted sources. Scan USB drives before opening. Keep your antivirus updated!" },
              
                { "ransomware tip", "Maintain offline backups using the 3-2-1 rule: 3 copies, 2 different media types, 1 offsite backup. Never pay the ransom!" },
             
                { "virus tip", "Scan all email attachments before opening, disable macros in Office files, and keep Windows Defender active." },
             
                { "trojan tip", "Only download software from official websites. Pirated software and crack tools often contain trojans." },
             
                { "spyware tip", "Use anti-spyware tools, avoid clicking pop-up ads, and regularly review your browser extensions." },
             
                { "keylogger tip", "Use on-screen keyboard for entering passwords on public computers. Keep antivirus updated to detect keyloggers." },

// Network security tips
            
                { "firewall tip", "Keep your firewall enabled even on private networks. It's your first line of defense against unauthorized access." },
            
                { "public wifi tip", "Never access banking or sensitive accounts on public Wi-Fi. Always use a VPN on public networks!" },
            
                { "vpn tip", "Use a paid, no-log VPN service like ProtonVPN, Mullvad, or ExpressVPN. Free VPNs often sell your data." },
             
                { "router tip", "Change your router's default password, disable WPS, enable WPA3 encryption, and update firmware regularly." },
            
                { "ddos tip", "Use Cloudflare or similar services for DDoS protection. Small businesses are also targets, not just big companies." },

// Authentication tips
                { "2fa tip", "Always enable two-factor authentication. Use authenticator apps like Google Authenticator or Authy instead of SMS when possible." },
            
                { "mfa tip", "Combine something you know (password) + something you have (phone) + something you are (fingerprint) for maximum security." },
            
                { "authentication tip", "Never share your 2FA codes with anyone - not even 'tech support' who calls you!" },

// Data protection tips
                { "encryption tip", "Encrypt sensitive files before cloud upload. Use VeraCrypt for folders or BitLocker for entire drives." },
            
                { "backup tip", "Follow the 3-2-1 backup rule: 3 copies, 2 different media types, 1 offsite backup. Test your restores regularly!" },
            
                { "data breach tip", "Use 'Have I Been Pwned' to check if your email was in a breach. Change passwords immediately if yes!" },

// Social engineering tips
                { "social engineering tip", "Never give passwords, 2FA codes, or personal info to anyone who calls you unexpectedly. Hang up and call back using an official number." },
           
                { "identity theft tip", "Freeze your credit with major bureaus (Equifax, Experian, TransUnion), monitor bank statements weekly, and shred sensitive documents." },

// Web security tips
                { "https tip", "Look for the padlock icon in your browser's address bar. Never enter passwords on HTTP sites - they're insecure!" },
          
                { "secure website tip", "Check for 'https://' and the padlock before entering any personal information online. Click the padlock to verify the certificate." },

// Email tips
                { "spam tip", "Never unsubscribe from suspicious emails - it confirms your address is active to spammers. Use your email's spam filters." },
           
                { "scam tip", "If something sounds too good to be true, it is! Never send money, gift cards, or cryptocurrency to online strangers." },

// Software tips
                { "antivirus tip", "Windows Defender is good for most home users. Keep it updated and run regular full system scans." },
          
                { "software update tip", "Enable automatic updates for your operating system, browsers, and all apps. Delaying updates leaves you vulnerable." },

// Privacy tips
                { "privacy tip", "Review your privacy settings on social media. Limit what you share publicly - oversharing helps attackers build profiles about you." },
           
                { "digital footprint tip", "Google yourself regularly. Remove old accounts and posts that reveal too much personal information." },

// Home security tips
                 { "iot security tip", "Keep IoT devices (smart cameras, smart fridges, Alexa) on a separate guest Wi-Fi network from your main computers." },
          
                { "smart home tip", "Change default passwords on all smart devices. Many come with 'admin/admin' - hackers scan for these!" },

// Business tips
                { "incident response tip", "Create an incident response plan: Detect → Contain → Eradicate → Recover → Learn. Practice with tabletop exercises." },
         
                { "risk management tip", "Identify your most valuable data, assess threats, and implement controls based on risk level (low/medium/high)." },
          
                { "security policy tip", "Document your security policies and train all employees. The weakest link is often human error." },

// Additional useful tips
                { "cloud security tip", "Encrypt files before uploading to cloud storage. Enable 2FA on your cloud accounts. Don't store sensitive data unencrypted." },
         
                { "mobile security tip", "Keep your phone updated, only install apps from official stores, and avoid sideloading apps from unknown sources." },
         
                { "email security tip", "Verify sender email addresses carefully. Scammers spoof 'From' addresses to look legitimate." },
         
                { "browser security tip", "Keep your browser updated, use uBlock Origin for ad blocking, and don't save passwords in your browser." },
         
                { "wifi security tip", "Change your default SSID (network name), use WPA3 or WPA2 encryption, and hide your SSID from broadcasting." },
         
                { "physical security tip", "Lock your devices when not in use. Use a privacy screen in public places. Don't leave laptops unattended." }
            };
            foreach (String keyword in TipsMemory.Keys)
            {
                if (Tips.Contains(keyword))
                {
                    TipRespond = TipsMemory[keyword];
                    Info = keyword;
                    break;
                }
                else
                {
                    TipRespond = "Sorry I don't understand that. Please ask me a general cybersecurity question or how to stay safe online.";
                }
            }

            return TipRespond;
        }
        public String Defination(String question,String Name)
        {
            String answered = "";
            Dictionary<string, string> defination = new Dictionary<string, string>()
            {
                 {"my name","Your name is " + Name + ". I've never heard that name before but it's abolutely unique!"},

                  { "cybersecurity", "Cybersecurity is the practice of protecting systems, networks, and data from digital attacks." },
            
            // Password-related terms
                { "password", "A password is a secret word or phrase used to access an account or system." },
           
                { "strong password", "Use at least 12 characters including letters, numbers, and symbols." },
           
                { "weak password", "Short passwords, common words, or personal information make passwords weak." },
           
                { "password manager", "A password manager securely stores and generates strong passwords." },
            
            // Threat types
                { "phishing", "Phishing is a scam where attackers trick users into giving sensitive information." },
           
                { "malware", "Malware is harmful software designed to damage or access systems without permission." },
            
                { "ransomware", "Ransomware is malware that locks files and demands payment to unlock them." },
           
                { "virus", "A virus is a type of malware that spreads by attaching itself to files." },
           
                { "worm", "A worm is malware that spreads automatically through networks." },
           
                { "trojan", "A Trojan is malware disguised as legitimate software." },
           
                { "spyware", "Spyware is malware that secretly collects user information." },
           
                { "adware", "Adware is software that displays unwanted advertisements." },
           
                { "keylogger", "A keylogger records keystrokes to capture sensitive information." },
           
                { "botnet", "A botnet is a network of infected computers controlled by an attacker." },
           
                { "ddos attack", "A DDoS attack overwhelms a system with traffic to make it unavailable." },
            
            // Security measures
           
                { "firewall", "A firewall is a system that blocks unauthorized access to or from a network." },
            
                { "encryption", "Encryption is the process of converting data into a secure code." },
           
                { "decryption", "Decryption is converting encrypted data back into readable form." },
           
                { "antivirus", "Antivirus software detects and removes malicious programs." },
           
                { "vpn", "A VPN is a secure connection that protects your internet activity." },
          
                { "backup", "A backup is a copy of data stored for recovery." },
          
                { "software update", "A software update fixes bugs and security vulnerabilities." },
            
            // Authentication & Authorization
           
                { "authentication", "Authentication is the process of verifying a user's identity." },
           
                { "authorization", "Authorization determines what a user is allowed to access." },
           
                { "multi factor authentication", "It is a security process that requires multiple methods to verify identity." },
           
                { "two factor authentication", "It is a type of authentication using two verification methods." },
            
            // Security incidents
           
                { "data breach", "A data breach is when sensitive information is accessed without permission." },
            
                { "cyberattack", "A cyberattack is an attempt to damage or access systems illegally." },
           
                { "cyber threat", "A cyber threat is a potential danger to systems or data." },
           
                { "identity theft", "Identity theft is stealing personal information for fraud." },
           
                { "spam", "Spam is unwanted or harmful messages sent online." },
           
                { "scam", "A scam is a fraudulent scheme to steal money or information." },
           
                { "cybercrime", "Cybercrime is illegal activity done using computers or the internet." },
            
           
                // People
           
                { "hacker", "A hacker is a person who gains unauthorized access to systems." },
           
                { "ethical hacking", "Ethical hacking is legal hacking used to find and fix security weaknesses." },
            
            // Web security
           
                { "https", "HTTPS is a secure version of HTTP that encrypts web traffic." },
          
                { "http", "HTTP is a protocol used to transfer data over the internet." },
           
                { "secure website", "A secure website uses encryption to protect user data." },
            
            // Social engineering
           
                { "social engineering", "Social engineering tricks people into revealing confidential information." },
            
            // Network concepts
           
                
               { "public wi-fi", "Public Wi-Fi is a shared internet connection that may be insecure." },
           
                { "private network", "A private network is restricted and secure from public access." },
           
                { "router", "A router directs internet traffic between devices." },
           
                { "ip address", "An IP address identifies a device on a network." },
           
                { "domain name", "A domain name is the address of a website." },
           
                { "network security", "Network security protects computer networks from threats." },
            
            // Security domains
           
                { "cloud security", "Cloud security protects data stored online." },
          
                { "information security", "Information security protects all forms of data." },
            
            // Privacy & Digital footprint
           
                { "digital footprint", "A digital footprint is the data you leave behind online." },
           
                { "privacy", "Privacy is the protection of personal information." },
            
            // Organizational security
          
                { "security policy", "A security policy is a set of rules to protect systems and data." },
           
                { "incident response", "Incident response is how organizations handle cyberattacks." },
           
                { "risk management", "Risk management is identifying and reducing cybersecurity risks." }

            };

            foreach (String keyword in defination.Keys)
            {
                if (question.Contains(keyword))
                {
                    answered = defination[keyword];
                    Info = keyword;
                    break;
                }
                else
                {
                    answered = "Sorry I don't understand that. Please ask me a general cybersecurity question or how to stay safe online.";
                }
            }

            return answered;
        }
        public String Explaination(String info)
        {
            String explain = "";

            Dictionary<string, string> explaination = new Dictionary<string, string>()
             {
   
                { "cybersecurity", "The practice of protecting systems, networks, and data from digital attacks. Tip 1: Always keep software updated. Tip 2: Use unique passwords for each account. Tip 3: Enable automatic security patches." },
  
                { "password", "A secret word or phrase used to authenticate access to a system. Tip 1: Make passwords at least 12 characters long. Tip 2: Avoid dictionary words or personal info. Tip 3: Never share passwords via email or text." },
   
                { "phishing", "Fraudulent attempts to trick you into revealing sensitive info via fake emails/websites. Tip 1: Hover over links before clicking. Tip 2: Check sender email addresses carefully. Tip 3: Never enter credentials on pop-up windows." },
   
                { "malware", "Malicious software designed to damage or exploit devices. Tip 1: Run regular antivirus scans. Tip 2: Don't download from untrusted sites. Tip 3: Disable auto-run for USB drives." },
   
                { "ransomware", "Malware that encrypts your files and demands payment for decryption. Tip 1: Maintain offline backups. Tip 2: Never pay the ransom (no guarantee). Tip 3: Use application whitelisting." },
   
                { "virus", "Self-replicating malware that attaches to clean files and spreads. Tip 1: Scan email attachments before opening. Tip 2: Keep your OS updated. Tip 3: Use real-time antivirus protection." },
   
                { "worm", "Standalone malware that replicates across networks without human action. Tip 1: Disable unnecessary network services. Tip 2: Use network segmentation. Tip 3: Apply security patches immediately." },
   
                { "trojan", "Malware disguised as legitimate software to trick users. Tip 1: Only download from official sources. Tip 2: Verify digital signatures. Tip 3: Use application control tools." },
  
                { "firewall", "Network security system that monitors and controls incoming/outgoing traffic. Tip 1: Keep firewall enabled at all times. Tip 2: Configure outbound rules carefully. Tip 3: Regularly review firewall logs." },
  
                { "encryption", "Converting data into unreadable code to protect confidentiality. Tip 1: Encrypt sensitive files and emails. Tip 2: Use full-disk encryption on laptops. Tip 3: Never lose encryption keys." },
   
                { "decryption", "The process of converting encrypted data back to readable form. Tip 1: Store decryption keys securely offline. Tip 2: Use key escrow for business. Tip 3: Test decryption regularly on backups." },
   
                { "authentication", "Verifying a user's identity before granting access. Tip 1: Use MFA everywhere possible. Tip 2: Avoid SMS-based codes when possible. Tip 3: Implement biometrics as a factor." },
   
                { "authorization", "Determining what resources a verified user can access. Tip 1: Follow least privilege principle. Tip 2: Review permissions quarterly. Tip 3: Use role-based access control (RBAC)." },
   
                { "multi factor authentication", "Using two or more verification methods (something you know/have/are). Tip 1: Prefer authenticator apps over SMS. Tip 2: Enroll backup codes. Tip 3: Enable for email and banking first." },
  
                
               { "two factor authentication", "A subset of MFA using exactly two verification factors. Tip 1: Use hardware tokens for high-value accounts. Tip 2: Never approve unexpected push notifications. Tip 3: Keep recovery keys safe." },
    
                { "data breach", "Unauthorized exposure of confidential information. Tip 1: Monitor credit reports regularly. Tip 2: Use breach notification services. Tip 3: Change passwords immediately after known breaches." },
   
                { "hacker", "Someone who exploits system vulnerabilities (ethically or maliciously). Tip 1: Learn hacking to defend better. Tip 2: Never retaliate against attackers. Tip 3: Report vulnerabilities responsibly." },
   
                { "ethical hacking", "Authorized hacking to find and fix security flaws. Tip 1: Always get written permission. Tip 2: Define scope clearly. Tip 3: Document all findings thoroughly." },
   
                { "spyware", "Software that secretly monitors user activity and steals data. Tip 1: Avoid clicking suspicious ads. Tip 2: Run anti-spyware tools weekly. Tip 3: Check browser extensions regularly." },
   
                { "adware", "Software that automatically displays unwanted advertisements. Tip 1: Decline 'free' software toolbars. Tip 2: Use ad-blockers cautiously. Tip 3: Uninstall unknown browser add-ons." },
   
                { "keylogger", "Malware that records every keystroke typed on a device. Tip 1: Use on-screen keyboard for passwords. Tip 2: Keep antivirus active. Tip 3: Inspect USB ports for hardware keyloggers." },
   
                { "botnet", "Network of infected devices controlled remotely by attackers. Tip 1: Secure IoT devices with strong passwords. Tip 2: Monitor unusual outbound traffic. Tip 3: Disable telnet and unused ports." },
    
                { "ddos attack", "Overwhelming a server with traffic from multiple sources to cause outage. Tip 1: Use DDoS protection services. Tip 2: Scale bandwidth dynamically. Tip 3: Implement rate limiting." },
    
                { "vpn", "Encrypts internet traffic and hides your IP address for privacy. Tip 1: Choose no-log VPN providers. Tip 2: Enable kill switch feature. Tip 3: Avoid free VPNs (they sell data)." },
   
                { "https", "Secure HTTP with encryption via SSL/TLS certificates. Tip 1: Never enter passwords on HTTP sites. Tip 2: Look for padlock icon in address bar. Tip 3: Install HTTPS Everywhere extension." },
    
                { "http", "Unencrypted web protocol vulnerable to eavesdropping. Tip 1: Assume all HTTP traffic is public. Tip 2: Upgrade any HTTP site you run to HTTPS. Tip 3: Avoid logins on HTTP pages." },
    
                { "secure website", "Website using HTTPS and valid SSL/TLS certificates. Tip 1: Verify certificate details by clicking padlock. Tip 2: Check for EV certificates on banking sites. Tip 3: Don't ignore 'Not Secure' warnings." },
    
                { "identity theft", "Using someone's personal information fraudulently. Tip 1: Freeze credit reports. Tip 2: Shred financial documents. Tip 3: File taxes early to prevent refund fraud." },
   
                { "social engineering", "Psychological manipulation to trick users into revealing data. Tip 1: Verify urgent requests via separate channel. Tip 2: Never share OTPs with 'support'. Tip 3: Create a family 'safe word'." },
   
                { "cyberattack", "Deliberate exploitation of systems for malicious purposes. Tip 1: Assume breach mindset. Tip 2: Practice incident response drills. Tip 3: Keep offline backups." },
   
                { "cyber threat", "Potential danger to systems, networks, or data. Tip 1: Subscribe to threat intelligence feeds. Tip 2: Perform regular risk assessments. Tip 3: Update threat models quarterly." },
    
                { "antivirus", "Software that detects and removes malicious programs. Tip 1: Keep virus definitions updated daily. Tip 2: Run full scans weekly. Tip 3: Don't run two antivirus programs together." },
    
                { "software update", "Patches that fix security vulnerabilities and bugs. Tip 1: Enable automatic updates. Tip 2: Don't postpone for more than 7 days. Tip 3: Verify updates come from official sources." },
   
                { "backup", "Copy of data used for recovery after loss or ransomware. Tip 1: Follow 3-2-1 rule (3 copies, 2 media, 1 offsite). Tip 2: Test restores quarterly. Tip 3: Keep backups disconnected when not used." },
   
                { "cloud security", "Protecting data, apps, and infrastructure in cloud environments. Tip 1: Never hardcode cloud keys in code. Tip 2: Enable cloud audit logging. Tip 3: Use cloud-native security tools." },
    
                { "network security", "Policies and tools to protect network integrity and usability. Tip 1: Segment IoT devices from main network. Tip 2: Disable unused ports and services. Tip 3: Monitor for rogue access points." },
   
                { "information security", "Preserving confidentiality, integrity, and availability of data. Tip 1: Classify data by sensitivity. Tip 2: Implement data loss prevention (DLP). Tip 3: Train employees on handling categories." },
   
                { "public wi-fi", "Unencrypted networks in public places, highly vulnerable. Tip 1: Always use VPN on public Wi-Fi. Tip 2: Disable auto-connect and file sharing. Tip 3: Forget network after use." },
   
                { "private network", "Restricted network with controlled access and encryption. Tip 1: Use WPA3 encryption for Wi-Fi. Tip 2: Change default router passwords. Tip 3: Disable WPS feature." },
   
                { "router", "Device that directs network traffic between devices and internet. Tip 1: Update router firmware regularly. Tip 2: Disable remote administration. Tip 3: Change default admin credentials." },
   
                { "ip address", "Unique identifier for devices on a network. Tip 1: Use VPN to hide your IP. Tip 2: Never share IP addresses publicly. Tip 3: Use dynamic IPs for home networks." },
   
                { "domain name", "Human-readable web address mapped to an IP address. Tip 1: Check domain spelling for typosquatting. Tip 2: Verify WHOIS info before trusting. Tip 3: Use domain reputation checkers." },
   
                { "spam", "Unsolicited bulk messages, often containing scams or malware. Tip 1: Never unsubscribe from suspicious spam. Tip 2: Use email filtering. Tip 3: Report spam to your provider." },
   
                { "scam", "Fraudulent scheme to steal money or information. Tip 1: 'If it's too good to be true, it is.' Tip 2: Never pay with gift cards. Tip 3: Verify charities before donating." },
    
                { "cybercrime", "Illegal activities conducted via computers or networks. Tip 1: Report incidents to law enforcement. Tip 2: Preserve evidence (logs, screenshots). Tip 3: Know local cybercrime reporting channels." },
    
                { "digital footprint", "Trail of data you leave online (posts, cookies, purchases). Tip 1: Google yourself regularly. Tip 2: Limit social media visibility. Tip 3: Delete old unused accounts." },
    
                { "privacy", "Control over how personal information is collected and used. Tip 1: Opt out of data brokers. Tip 2: Use privacy-focused browsers. Tip 3: Adjust app permission settings." },
    
                { "security policy", "Documented rules for protecting organizational assets. Tip 1: Make policies readable (not legalese). Tip 2: Enforce with technical controls. Tip 3: Review annually." },
   
                { "incident response", "Structured process for handling security breaches. Tip 1: Create a written IR plan. Tip 2: Practice tabletop exercises. Tip 3: Document lessons learned after incidents." },
   
                { "risk management", "Identifying, assessing, and mitigating security risks. Tip 1: Prioritize risks by impact/likelihood. Tip 2: Accept, transfer, mitigate, or avoid. Tip 3: Review risks quarterly." },
   
                { "strong password", "Complex password resistant to guessing/cracking (length > randomness). Tip 1: Use 4+ random words (e.g., correct-horse-battery). Tip 2: Minimum 15 characters. Tip 3: Never reuse across sites." },
    
                { "password manager", "Software that generates and stores complex passwords securely. Tip 1: Use master password that's very strong. Tip 2: Enable MFA on the manager. Tip 3: Choose offline or zero-knowledge options." },
   
                { "weak password", "Easily guessed password (short, common, personal). Tip 1: Avoid 'password123', 'qwerty', birthdays. Tip 2: Never use 'admin' or 'password'. Tip 3: Check if your password appears in breach lists (haveibeenpwned)." }
             };

            foreach (String keyword in explaination.Keys)
            {
                if (info.Contains(keyword))
                {
                    explain = explaination[keyword];
                    Info = keyword;
                    break;
                }
                else
                {
                    explain = "Sorry I don't understand that. Please ask me a general cybersecurity question or how to stay safe online.";
                }
            }

            return explain;
        }


    }
}