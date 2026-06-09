namespace HangmanGame;

public partial class GameForm : Form
{
    private readonly string[] wordList = {
        "CODE", "LOOP", "FILE", "DATA", "BYTE",
        "DISK", "PORT", "FONT", "ICON", "LIST",
        "NODE", "SORT", "TREE", "LINK", "HASH",
        "STACK", "QUEUE", "CLASS", "MOUSE", "PIXEL",
        "LINUX", "CACHE", "ARRAY", "PATCH", "SHELL",
        "WINDOW", "OBJECT", "KERNEL", "BUFFER", "SYNTAX"
    };

    private string currentWord = "";
    private char[] guessedLetters = Array.Empty<char>();
    private int wrongGuesses = 0;
    private const int MaxWrong = 6;

    private Panel drawingPanel = null!;
    private Label wordLabel = null!;
    private Label usedLettersLabel = null!;
    private TextBox letterInput = null!;
    private Button guessButton = null!;
    private Button newGameButton = null!;
    private Label statusLabel = null!;
    private Label wrongCountLabel = null!;

    public GameForm()
    {
        InitializeComponent();
        BuildUI();
        StartNewGame();
    }

    private void BuildUI()
    {
        this.Text = "Hangman";
        this.Size = new Size(750, 580);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(30, 30, 40);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        drawingPanel = new Panel();
        drawingPanel.Location = new Point(20, 20);
        drawingPanel.Size = new Size(300, 320);
        drawingPanel.BackColor = Color.FromArgb(45, 45, 60);
        drawingPanel.BorderStyle = BorderStyle.None;
        drawingPanel.Paint += DrawingPanel_Paint;

        wordLabel = new Label();
        wordLabel.Location = new Point(340, 30);
        wordLabel.Size = new Size(380, 60);
        wordLabel.Font = new Font("Courier New", 22, FontStyle.Bold);
        wordLabel.ForeColor = Color.FromArgb(100, 220, 255);
        wordLabel.TextAlign = ContentAlignment.MiddleCenter;

        wrongCountLabel = new Label();
        wrongCountLabel.Location = new Point(340, 100);
        wrongCountLabel.Size = new Size(380, 30);
        wrongCountLabel.Font = new Font("Segoe UI", 11);
        wrongCountLabel.ForeColor = Color.FromArgb(255, 150, 100);
        wrongCountLabel.TextAlign = ContentAlignment.MiddleCenter;

        Label usedTitle = new Label();
        usedTitle.Text = "Used Letters:";
        usedTitle.Location = new Point(340, 140);
        usedTitle.Size = new Size(380, 25);
        usedTitle.Font = new Font("Segoe UI", 10);
        usedTitle.ForeColor = Color.FromArgb(170, 170, 200);

        usedLettersLabel = new Label();
        usedLettersLabel.Location = new Point(340, 165);
        usedLettersLabel.Size = new Size(380, 60);
        usedLettersLabel.Font = new Font("Courier New", 13, FontStyle.Bold);
        usedLettersLabel.ForeColor = Color.FromArgb(255, 200, 100);
        usedLettersLabel.TextAlign = ContentAlignment.MiddleLeft;

        statusLabel = new Label();
        statusLabel.Location = new Point(340, 235);
        statusLabel.Size = new Size(380, 40);
        statusLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        statusLabel.ForeColor = Color.LightGreen;
        statusLabel.TextAlign = ContentAlignment.MiddleCenter;

        Label enterLabel = new Label();
        enterLabel.Text = "Enter a letter:";
        enterLabel.Location = new Point(340, 285);
        enterLabel.Size = new Size(380, 25);
        enterLabel.Font = new Font("Segoe UI", 10);
        enterLabel.ForeColor = Color.FromArgb(170, 170, 200);

        letterInput = new TextBox();
        letterInput.Location = new Point(340, 310);
        letterInput.Size = new Size(80, 35);
        letterInput.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        letterInput.MaxLength = 1;
        letterInput.BackColor = Color.FromArgb(60, 60, 80);
        letterInput.ForeColor = Color.White;
        letterInput.BorderStyle = BorderStyle.FixedSingle;
        letterInput.CharacterCasing = CharacterCasing.Upper;
        letterInput.KeyDown += (s, e) => {
            if (e.KeyCode == Keys.Enter) GuessButton_Click(s, e);
        };

        guessButton = new Button();
        guessButton.Text = "Guess";
        guessButton.Location = new Point(440, 308);
        guessButton.Size = new Size(100, 38);
        guessButton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        guessButton.BackColor = Color.FromArgb(70, 130, 200);
        guessButton.ForeColor = Color.White;
        guessButton.FlatStyle = FlatStyle.Flat;
        guessButton.FlatAppearance.BorderSize = 0;
        guessButton.Cursor = Cursors.Hand;
        guessButton.Click += GuessButton_Click;

        newGameButton = new Button();
        newGameButton.Text = "New Game";
        newGameButton.Location = new Point(550, 308);
        newGameButton.Size = new Size(110, 38);
        newGameButton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        newGameButton.BackColor = Color.FromArgb(60, 160, 100);
        newGameButton.ForeColor = Color.White;
        newGameButton.FlatStyle = FlatStyle.Flat;
        newGameButton.FlatAppearance.BorderSize = 0;
        newGameButton.Cursor = Cursors.Hand;
        newGameButton.Click += (s, e) => StartNewGame();

        Label hintLabel = new Label();
        hintLabel.Text = "Guess the hidden word before the man is hanged!";
        hintLabel.Location = new Point(20, 360);
        hintLabel.Size = new Size(700, 25);
        hintLabel.Font = new Font("Segoe UI", 10, FontStyle.Italic);
        hintLabel.ForeColor = Color.FromArgb(130, 130, 160);
        hintLabel.TextAlign = ContentAlignment.MiddleCenter;

        this.Controls.AddRange(new Control[] {
            drawingPanel, wordLabel, wrongCountLabel,
            usedTitle, usedLettersLabel, statusLabel,
            enterLabel, letterInput, guessButton, newGameButton,
            hintLabel
        });
    }

    private void StartNewGame()
    {
        Random rnd = new Random();
        currentWord = wordList[rnd.Next(wordList.Length)];

        guessedLetters = Array.Empty<char>();
        wrongGuesses = 0;

        UpdateWordDisplay();
        UpdateUsedLetters();
        wrongCountLabel.Text = $"Wrong guesses: {wrongGuesses} / {MaxWrong}";
        statusLabel.Text = "";
        letterInput.Text = "";
        letterInput.Enabled = true;
        guessButton.Enabled = true;
        letterInput.Focus();

        drawingPanel.Invalidate();
    }

    private void GuessButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(letterInput.Text)) return;

        char letter = letterInput.Text[0];
        letterInput.Text = "";
        letterInput.Focus();

        if (guessedLetters.Contains(letter))
        {
            MessageBox.Show($"You already guessed '{letter}'!", "Duplicate",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        guessedLetters = guessedLetters.Append(letter).ToArray();

        if (currentWord.Contains(letter))
        {
            UpdateWordDisplay();

            // IsWordComplete بتشوف لو كل الحروف الفريدة في الكلمة اتخمنت
            if (IsWordComplete())
            {
                statusLabel.Text = "YOU WIN!";
                statusLabel.ForeColor = Color.LightGreen;
                letterInput.Enabled = false;
                guessButton.Enabled = false;
                MessageBox.Show($"The word was: {currentWord}", "You Win!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            wrongGuesses++;
            wrongCountLabel.Text = $"Wrong guesses: {wrongGuesses} / {MaxWrong}";
            drawingPanel.Invalidate();

            if (wrongGuesses >= MaxWrong)
            {
                statusLabel.Text = "YOU LOSE!";
                statusLabel.ForeColor = Color.FromArgb(255, 80, 80);
                letterInput.Enabled = false;
                guessButton.Enabled = false;
                MessageBox.Show($"The word was: {currentWord}", "You Lose!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        UpdateUsedLetters();
    }

    private void UpdateWordDisplay()
    {
        string display = string.Join("  ", currentWord.Select(c =>
            guessedLetters.Contains(c) ? c.ToString() : "_"
        ));
        wordLabel.Text = display;
    }

    private void UpdateUsedLetters()
    {
        usedLettersLabel.Text = string.Join("  ", guessedLetters);
    }

 
    private bool IsWordComplete()
    {
        return currentWord.Distinct().All(c => guessedLetters.Contains(c));
    }

    private void DrawingPanel_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        Pen gallowsPen = new Pen(Color.FromArgb(180, 160, 120), 5);
        Pen bodyPen = new Pen(Color.FromArgb(100, 220, 255), 4);

        g.DrawLine(gallowsPen, 20, 300, 280, 300);
        g.DrawLine(gallowsPen, 60, 300, 60, 30);
        g.DrawLine(gallowsPen, 60, 30, 180, 30);
        g.DrawLine(gallowsPen, 180, 30, 180, 70);

        if (wrongGuesses >= 1)
            g.DrawEllipse(bodyPen, 155, 70, 50, 50);

        if (wrongGuesses >= 2)
            g.DrawLine(bodyPen, 180, 120, 180, 210);

        if (wrongGuesses >= 3)
            g.DrawLine(bodyPen, 180, 140, 130, 180);

        if (wrongGuesses >= 4)
            g.DrawLine(bodyPen, 180, 140, 230, 180);

        if (wrongGuesses >= 5)
            g.DrawLine(bodyPen, 180, 210, 140, 270);

        if (wrongGuesses >= 6)
            g.DrawLine(bodyPen, 180, 210, 220, 270);

        gallowsPen.Dispose();
        bodyPen.Dispose();
    }
}