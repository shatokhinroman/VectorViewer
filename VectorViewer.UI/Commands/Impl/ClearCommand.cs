namespace VectorViewer.UI.Commands.Impl
{
    using System;
    using Base;

    public class ClearCommand : CommandBase, IClearCommand
    {
        public Action Clear { get; private set; }

        public Func<bool> CanClear { get; private set; }

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => CanClear != null && CanClear.Invoke();

        /// <inheritdoc />
        public override void Execute(object parameter) => Clear();

        public IClearCommand Initialize(Action clear, Func<bool> canClear)
        {
            Clear = clear;
            CanClear = canClear;

            return this;
        }
    }
}