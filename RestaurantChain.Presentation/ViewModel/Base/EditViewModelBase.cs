using System.Windows.Input;

namespace RestaurantChain.Presentation.ViewModel.Base;

/// <summary>
///     Базовый класс для редактирования записей справочников и прочих
/// </summary>
internal abstract class EditViewModelBase : ViewModelBase
{
    /// <summary>
    /// Действие на кнопку ОК.
    /// </summary>
    public Action OnSaveSuccess;

    /// <summary>
    /// Действие на кнопку отмена.
    /// </summary>
    public Action OnCancel;

    /// <summary>
    /// Команда ОК.
    /// </summary>
    public ICommand EnterCommand { get; set; }

    /// <summary>
    /// Текущий ID, который редактируем.
    /// </summary>
    public int? CurrentId { get; }

    protected EditViewModelBase(int? currentId)
    {
        CurrentId = currentId;
    }

    /// <summary>
    /// Метод валидации.
    /// </summary>
    /// <returns></returns>
    public abstract bool Validate();

    /// <summary>
    /// Форма открылась на создание, если true
    /// </summary>
    public bool IsNew => CurrentId == null;
}