using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    class BackUpStep : IStep
    {
        private string _backUpPath;
        private IStep _nextStep;
        private Dictionary<string, List<string>> _conditionBackup;
        public BackUpStep(string backUpPath, IStep nextStep)
        {
            _backUpPath = backUpPath;
            _nextStep = nextStep;
        }

        public IStep Step(BLLEntity entity)
        {
            //TODO: Добавить сравнение backup & current Folder.
            BackupInitialise();
            var result = _nextStep.Step(entity);

            //TODO: Доп действия если надо

            return result;
        }

        private void BackupInitialise()
        {
            //TODO: Читаем файлы из backup
            //TODO: Читаем файлы из currentFolder

            //TODO: Сравниваем файлы из backup и currentFolder
            // тут будет фор где мы сравниваем каррент папку и бекап папку если то выполняем след шаг ниже
            //TODO: Если  файл backup относится к файлу currentFolder, то добавляем файл backup в _conditionBackup под ключом имени файла из currentFolder
        }
    }
}
