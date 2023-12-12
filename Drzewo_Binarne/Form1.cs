namespace Drzewo_Binarne

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DzewoBinarne w1 = new DzewoBinarne(5);
            w1.Add2(8);
            w1.Add2(4);
            w1.Add2(3);
            w1.Add2(4);
            w1.Add2(7);
            w1.Add2(6);
            w1.WyswietlWartosciMessageBox();
        }
        class W�zel3
        {
            public int wartosc;
            public W�zel3 rodzic;
            public W�zel3 lewedziecko;
            public W�zel3 prawedziecko;
            public W�zel3(int liczba)
            {
                this.wartosc = liczba;
            }

            public void Add2(int liczba)
            {
                var dziecko = new W�zel3(liczba);
                dziecko.rodzic = this;
                if (liczba < this.wartosc)
                {
                    this.lewedziecko = dziecko;
                }
                else
                {
                    this.prawedziecko = dziecko;
                }
            }
        }
        class DzewoBinarne
        {
            public W�zel3 korzen;
            public int liczbawenzld;
            public DzewoBinarne(int liczba)
            {
                this.korzen = new(liczba);
                this.liczbawenzld = 1;
            }
            public void Add(int liczba)
            {
                DodajRekurencyjnie(this.korzen, liczba);
            }

            public void Add2(int liczba)
            {
                W�zel3 rodzic = this.ZnadzRodzica(liczba);
                rodzic.Add2(liczba);
            }

            public W�zel3 ZnadzRodzica(int liczba)
            {
                var w = this.korzen;
                while (true)
                {
                    if (liczba < w.wartosc)
                    {
                        if (w.lewedziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.lewedziecko;
                        }
                    }
                    else
                    {
                        if (w.prawedziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.prawedziecko;
                        }
                    }
                }
            }

            public W�zel3 Znajdz(int liczba)
            {
                var current = this.korzen;
                while (current != null)
                {
                    if (liczba == current.wartosc)
                        return current;
                    else if (liczba < current.wartosc)
                        current = current.lewedziecko;
                    else
                        current = current.prawedziecko;
                }
                return null;
            }

            public W�zel3 ZnajdzMin(W�zel3 w)
            {
                while (w.lewedziecko != null)
                    w = w.lewedziecko;
                return w;
            }

            public W�zel3 ZnajdzMax(W�zel3 w)
            {
                while (w.prawedziecko != null)
                    w = w.prawedziecko;
                return w;
            }

            public W�zel3 Nastepnik(W�zel3 w)
            {
                if (w.prawedziecko != null)
                    return ZnajdzMin(w.prawedziecko);

                var rodzic = w.rodzic;
                while (rodzic != null && w == rodzic.prawedziecko)
                {
                    w = rodzic;
                    rodzic = rodzic.rodzic;
                }
                return rodzic;
            }


            private void DodajRekurencyjnie(W�zel3 aktualny, int liczba)
            {
                if (liczba < aktualny.wartosc)
                {
                    if (aktualny.lewedziecko == null)
                    {
                        aktualny.lewedziecko = new W�zel3(liczba);
                        aktualny.lewedziecko.rodzic = aktualny;
                        this.liczbawenzld++;
                    }
                    else
                    {
                        DodajRekurencyjnie(aktualny.lewedziecko, liczba);
                    }
                }
                else
                {
                    if (aktualny.prawedziecko == null)
                    {
                        aktualny.prawedziecko = new W�zel3(liczba);
                        aktualny.prawedziecko.rodzic = aktualny;
                        this.liczbawenzld++;
                    }
                    else
                    {
                        DodajRekurencyjnie(aktualny.prawedziecko, liczba);
                    }
                }
            }
            //WAZNE NA AISD
            public void Usun(int liczba)
            {
                W�zel3 doUsuniecia = Znajdz(liczba);
                if (doUsuniecia == null) return; // Node not found

                UsunW�zel(doUsuniecia);
            }

            private void UsunW�zel(W�zel3 w)
            {
                if (w.lewedziecko == null && w.prawedziecko == null)
                {
                    // Case 1: brak dzieci
                    ZamienRodzica(w, null);
                }
                else if (w.lewedziecko == null)
                {
                    // Case 2: jedno dziecko prawe
                    ZamienRodzica(w, w.prawedziecko);
                }
                else if (w.prawedziecko == null)
                {
                    // Case 2: jedno dziecko lewe
                    ZamienRodzica(w, w.lewedziecko);
                }
                else
                {
                    // Case 3: dwoje dzieci
                    W�zel3 nastepnik = ZnajdzMin(w.prawedziecko);
                    w.wartosc = nastepnik.wartosc;
                    UsunW�zel(nastepnik);
                }
            }

            private void ZamienRodzica(W�zel3 stary, W�zel3 nowy)
            {
                if (stary.rodzic == null)
                {
                    korzen = nowy;
                }
                else if (stary == stary.rodzic.lewedziecko)
                {
                    stary.rodzic.lewedziecko = nowy;
                }
                else
                {
                    stary.rodzic.prawedziecko = nowy;
                }

                if (nowy != null)
                {
                    nowy.rodzic = stary.rodzic;
                }
            }

            public void WyswietlWartosciMessageBox()
            {
                WyswietlWartosciMessageBoxRekurencyjnie(this.korzen);
            }

            private void WyswietlWartosciMessageBoxRekurencyjnie(W�zel3 aktualny)
            {
                if (aktualny != null)
                {
                    MessageBox.Show(aktualny.wartosc.ToString(), "Dodany w�ze�");
                    WyswietlWartosciMessageBoxRekurencyjnie(aktualny.lewedziecko);
                    WyswietlWartosciMessageBoxRekurencyjnie(aktualny.prawedziecko);
                }
            }
        }
    }
}