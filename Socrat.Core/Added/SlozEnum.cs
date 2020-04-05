using System.ComponentModel.DataAnnotations;

namespace Socrat.Core.Added
{
    public enum SlozEnum
    {
        [Display(Name = "Не определена")]
        None,
        /// <summary>
        /// Нарезка
        /// </summary>
        [Display(Name = "Нарезка")]
        GlassCutting,
        /// <summary>
        /// Шаблон
        /// </summary>
        [Display(Name = "Шаблон")]
        Template,
        /// <summary>
        /// Форма
        /// </summary>
        [Display(Name = "Форма")]
        Figure,
        /// <summary>
        /// Асиметричные камеры
        /// </summary>
        [Display(Name = "Асиметричные камеры")]
        AsimetricFrames,
        /// <summary>
        /// Пленка
        /// </summary>
        [Display(Name = "Пленка")]
        Film,
        /// <summary>
        /// Газ
        /// </summary>
        [Display(Name = "Аргон")]
        Gaz,
        /// <summary>
        /// Шпроссы
        /// </summary>
        [Display(Name = "Шпроссы")]
        Shpross,
        /// <summary>
        /// Армированое стекло
        /// </summary>
        [Display(Name = "Армированое стекло")]
        ArmedGlass,
        /// <summary>
        /// Триплекс
        /// </summary>
        [Display(Name = "Триплекс")]
        Triplex,
        /// <summary>
        /// Очень маленькая площадь
        /// </summary>
        [Display(Name = "Очень маленькая площадь")]
        TinySquare,
        /// <summary>
        /// Маленькая площадь
        /// </summary>
        [Display(Name = "Маленькая площадь")]
        SmallSquare,
        /// <summary>
        /// Большая площадь
        /// </summary>
        [Display(Name = "Большая площадь")]
        LargeSquare,
        /// <summary>
        /// Жалюзи
        /// </summary>
        [Display(Name = "Жалюзи")]
        Blind,
        /// <summary>
        /// Рамка TGI/TE/СН 
        /// </summary>
        [Display(Name = "Рамка TGI/TE/СН")]
        FrameTGI,
        /// <summary>
        /// Рамка ПВХ 
        /// </summary>
        [Display(Name = "Рамка ПВХ")]
        FramePVH,
        /// <summary>
        /// Закаленное стекло
        /// </summary>
        [Display(Name = "Закаленное стекло")]
        TemperedGlass,
        /// <summary>
        /// Шов на пленке
        /// </summary>
        [Display(Name = "Шов на пленке")]
        FilmSeam
    }
}