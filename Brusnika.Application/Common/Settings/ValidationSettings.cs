﻿namespace Brusnika.Application.Common.Settings;

public class ValidationSettings
{
    public const string SectionName = "ValidationSettings";
    
    public int GuidLength { get; init; }
    
    public int CardSideMaxLength { get; init; }
    public int CardSideMinLength { get; init; }
    public int CardImageLength { get; init; } 
    
    public int DeckNameLength { get; init; }
    public int DeckDescriptionLength { get; init; }
    public int DeckPasswordHashLength { get; init; }
    public int DeckPasswordMinLength { get; init; }
    public int DeckPasswordMaxLength { get; init; }

    public int UserLoginLength { get; init; }
    public int UserEmailLength { get; init; }
    public int UserFirstNameLength { get; init; }
    public int UserLastNameLength { get; init; }
    public int UserLocationLength { get; init; }
    public int UserAvatarsCount { get; init; }
    public int UserRefreshTokenLength { get; init; }
    public int UserRecoveryCodeLength { get; init; }
    public int UserPasswordHashLength { get; init; }
    public int UserPasswordMinLength { get; init; }
    public int UserPasswordMaxLength { get; init; }
    public int UserPasswordRecoveryCodeLength { get; init; }

    public int ImageNameLength { get; init; }
    public int ImageFileExtensionLength { get; init; }

    public int SideNameLength { get; init; }
    
    public int StatisticTopUsersCount { get; init; }
}