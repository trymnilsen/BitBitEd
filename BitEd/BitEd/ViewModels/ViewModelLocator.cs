using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEd.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<DirectoryViewModel>();
            SimpleIoc.Default.Register<ProjectViewModel>();
            SimpleIoc.Default.Register<InspectorViewModel>();
            SimpleIoc.Default.Register<StatusBarViewModel>();
            SimpleIoc.Default.Register<ScreenViewModel>();
        }

        /// <summary>
        /// Gets the Directory view's viewmodel
        /// </summary>

        public DirectoryViewModel DirectoryVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DirectoryViewModel>();
            }
        }

        /// <summary>
        /// Gets the Statusbar's view viewmodel
        /// </summary>
        public StatusBarViewModel StatusBarVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StatusBarViewModel>();
            }
        }
        /// <summary>
        /// Gets the ProjectTree's view viewmodel
        /// </summary>

        public ProjectViewModel ProjectVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProjectViewModel>();
            }
        }

        /// <summary>
        /// Gets the Inspector view viewmodel
        /// </summary>

        public InspectorViewModel InspectorVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InspectorViewModel>();
            }
        }

        /// <summary>
        /// Gets the ScreenEditors view viewmodel
        /// </summary>
        public ScreenViewModel ScreenVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ScreenViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {

        }
    }
}
