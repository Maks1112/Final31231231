using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kassa.Bl;

namespace Kassa
{
    internal class MainPresenter
    {
        private readonly IForm view;
        private readonly IManeger manager;
        private readonly IMessageService message;
        public MainPresenter(IForm _view, IManeger manager,IMessageService _message)
        {
            message = _message;
            view = _view;
            this.manager = manager;
            view.SetCounterTrains(0);

            view.SaveButClick += view_SaveButClick;
            view.LoadButtonClick += view_LoadButtonClick;
            view.OrderATicket += view_OrderATicket;
            view.OrderTwoATicket += view_OrderTwoATicket;
        }

        void view_OrderTwoATicket(object sender, EventArgs e)
        {
            try
            {
                int n = view.OrderTwo;
                List<Train> lst = view.GetDataFromDataGridView();
                int index=-1;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].NomerPoezda == n)
                    {
                        index = lst.IndexOf(lst[i]);
                        int count = lst[index].KolichestvoMest;
                        if(count==0)
                            throw new Exception("Места закончились!");
                        lst[index] = new Train(lst[index].NomerPoezda, lst[index].DataOtpravleniya, count - 1, lst[index].Name);
                    }
                }
                if(index==-1)
                    throw new Exception("Поезд не найден!");
                view.ClearGridView();
                foreach (Train t in lst)
                {
                    view.InsertRows(t.NomerPoezda, t.Name, t.KolichestvoMest, t.DataOtpravleniya);
                }
                view.SetCounterTrains(lst.Count);
            }
            catch (Exception ee)
            {
                
               message.ShowError(ee.Message); 
            }
            
        }

        void view_OrderATicket(object sender, EventArgs e)
        {
            try
            {
                int n = view.OrderOne;

                List<Train> lst = view.GetDataFromDataGridView();

                int index = -1;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].NomerPoezda == n)
                    {
                        index = lst.IndexOf(lst[i]);
                        int count = lst[index].KolichestvoMest;
                        if (count == 0)
                            throw new Exception("Места закончились!");
                        lst[index] = new Train(lst[index].NomerPoezda, lst[index].DataOtpravleniya, count - 1, lst[index].Name);
                    }
                }
                if (index == -1)
                    throw new Exception("Поезд не найден!");
                view.ClearGridView();
                foreach (Train t in lst)
                {
                    view.InsertRows(t.NomerPoezda, t.Name, t.KolichestvoMest, t.DataOtpravleniya);
                }
                view.SetCounterTrains(lst.Count);
            }
            catch (Exception ee)
            {
                
               message.ShowError(ee.Message);
            }
           
        }

        void view_LoadButtonClick(object sender, EventArgs e)
        {
            try
            {
                string fname = view.FilePath;
                view.ClearGridView();
                var lst = manager.DeSerializeFile(fname);
                foreach (Train t in lst)
                {
                    view.InsertRows(t.NomerPoezda, t.Name, t.KolichestvoMest, t.DataOtpravleniya);
                }
                view.SetCounterTrains(lst.Count);
                message.ShowMessage("Данные успешно загружены!");
            }
            catch (Exception ee)
            {
                
               message.ShowError(ee.Message);
            }
           

        }

        private void view_SaveButClick(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog()
                {
                    Title = "Выберите файл",
                    InitialDirectory = Environment.CurrentDirectory,
                    RestoreDirectory = true,
                    Filter = @"Файлы данных .dat|*.dat|All Files|*.*",
                    FilterIndex = 0
                };
                if (save.ShowDialog() == DialogResult.OK)
                {
                    manager.SerializeToFile(view.GetDataFromDataGridView(), save.FileName);
                }
                message.ShowMessage("Данные успешно сохранились!");
            }
            catch (Exception ee)
            {
                
               message.ShowError(ee.Message);
            }
          
           
        }


    }
}
