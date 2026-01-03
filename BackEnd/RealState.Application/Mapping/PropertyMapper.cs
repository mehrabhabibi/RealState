using RealState.Domain.DTOs.Properties;
using RealState.Domain.Entities;

namespace RealState.Application.Mapping;

public static class PropertyMapper
{
    public static Property ToDataModel(this CreatePropertyDto createDto)
    {
        return new Property
        {
            Title = createDto.Title,
            Country = createDto.Country,
            City = createDto.City,
            Address = createDto.Address,
            Type = createDto.Type,
            Bedrooms = createDto.Bedrooms,
            Price = createDto.Price,
            Status = createDto.Status,
            Description = createDto.Description,
            Details = createDto.Details.ToDataModel(),
            Images = createDto.Images.ToDataModel(),
            Videos = createDto.Videos.ToDataModel()
        };
    }

    public static PropertyDetails ToDataModel(this CreatePropertyDetailsDto detailsDto)
    {
        return new PropertyDetails
        {
            SquareMeters = detailsDto.SquareMeters,
            Bathrooms = detailsDto.Bathrooms,
            Floors = detailsDto.Floors,
            FurnishingStatus = detailsDto.FurnishingStatus,
            HasParking = detailsDto.HasParking,
            HasBalcony = detailsDto.HasBalcony,
            HasGarden = detailsDto.HasGarden,
            HasPool = detailsDto.HasPool,
            HasGym = detailsDto.HasGym,
            YearBuilt = detailsDto.YearBuilt,
            EnergyRating = detailsDto.EnergyRating,
            AdditionalFeatures = detailsDto.AdditionalFeatures,
        };
    }

    public static IEnumerable<PropertyImage> ToDataModel(this IEnumerable<CreatePropertyImageDto> imageDtos)
    {
        return imageDtos.Select(c => c.ToDataModel());
    }

    public static PropertyImage ToDataModel(this CreatePropertyImageDto imageDto)
    {
        return new PropertyImage
        {
            ImageUrl = imageDto.ImageUrl,
            IsMain = imageDto.IsMain
        };
    }

    public static IEnumerable<PropertyVideo> ToDataModel(this IEnumerable<CreatePropertyVideoDto> videoDtos)
    {
        return videoDtos.Select(c => c.ToDataModel());
    }

    public static PropertyVideo ToDataModel(this CreatePropertyVideoDto videoDto)
    {
        return new PropertyVideo
        {
            ThumbnailUrl = videoDto.ThumbnailUrl,
            VideoUrl = videoDto.VideoUrl
        };
    }

    public static Property ToDataModel(this PropertyDto dto)
    {
        return new Property
        {
            Id = dto.Id,
            Title = dto.Title,
            Country = dto.Country,
            City = dto.City,
            Address = dto.Address,
            Type = dto.Type,
            Bedrooms = dto.Bedrooms,
            Price = dto.Price,
            Status = dto.Status,
            Description = dto.Description,
            Details = dto.Details.ToDataModel(),
            Images = dto.Images.ToDataModel(),
            Videos = dto.Videos.ToDataModel()
        };
    }

    public static PropertyDetails ToDataModel(this PropertyDetailsDto detailsDto)
    {
        return new PropertyDetails
        {
            Id = detailsDto.Id,
            PropertyId = detailsDto.PropertyId,
            SquareMeters = detailsDto.SquareMeters,
            Bathrooms = detailsDto.Bathrooms,
            Floors = detailsDto.Floors,
            FurnishingStatus = detailsDto.FurnishingStatus,
            HasParking = detailsDto.HasParking,
            HasBalcony = detailsDto.HasBalcony,
            HasGarden = detailsDto.HasGarden,
            HasPool = detailsDto.HasPool,
            HasGym = detailsDto.HasGym,
            YearBuilt = detailsDto.YearBuilt,
            EnergyRating = detailsDto.EnergyRating,
            AdditionalFeatures = detailsDto.AdditionalFeatures,
        };
    }

    public static IEnumerable<PropertyImage> ToDataModel(this IEnumerable<PropertyImageDto> imageDtos)
    {
        return imageDtos.Select(c => c.ToDataModel());
    }

    public static PropertyImage ToDataModel(this PropertyImageDto imageDto)
    {
        return new PropertyImage
        {
            Id = imageDto.Id,
            PropertyId = imageDto.PropertyId,
            ImageUrl = imageDto.ImageUrl,
            IsMain = imageDto.IsMain
        };
    }

    public static IEnumerable<PropertyVideo> ToDataModel(this IEnumerable<PropertyVideoDto> videoDtos)
    {
        return videoDtos.Select(c => c.ToDataModel());
    }

    public static PropertyVideo ToDataModel(this PropertyVideoDto videoDto)
    {
        return new PropertyVideo
        {
            Id = videoDto.Id,
            PropertyId = videoDto.PropertyId,
            ThumbnailUrl = videoDto.ThumbnailUrl,
            VideoUrl = videoDto.VideoUrl
        };
    }




    public static PropertyDto ToDto(this Property dataModel)
    {
        return new PropertyDto
        {
            Id = dataModel.Id,
            Title = dataModel.Title,
            Country = dataModel.Country,
            City = dataModel.City,
            Address = dataModel.Address,
            Type = dataModel.Type,
            Bedrooms = dataModel.Bedrooms,
            Price = dataModel.Price,
            Status = dataModel.Status,
            Description = dataModel.Description,
            CreatedAt = dataModel.CreatedAt,
            CreatedBy = dataModel.CreatedBy,
            UpdatedAt = dataModel.UpdatedAt,
            Details = dataModel.Details.ToDto(),
            Images = dataModel.Images.ToDto(),
            Videos = dataModel.Videos.ToDto()
        };
    }

    public static PropertyDetailsDto ToDto(this PropertyDetails propertyDetails)
    {
        return new PropertyDetailsDto
        {
            Id = propertyDetails.Id,
            PropertyId = propertyDetails.PropertyId,
            SquareMeters = propertyDetails.SquareMeters,
            Bathrooms = propertyDetails.Bathrooms,
            Floors = propertyDetails.Floors,
            FurnishingStatus = propertyDetails.FurnishingStatus,
            HasParking = propertyDetails.HasParking,
            HasBalcony = propertyDetails.HasBalcony,
            HasGarden = propertyDetails.HasGarden,
            HasPool = propertyDetails.HasPool,
            HasGym = propertyDetails.HasGym,
            YearBuilt = propertyDetails.YearBuilt,
            EnergyRating = propertyDetails.EnergyRating,
            AdditionalFeatures = propertyDetails.AdditionalFeatures,
        };
    }

    public static IEnumerable<PropertyImageDto> ToDto(this IEnumerable<PropertyImage> propertyImages)
    {
        return propertyImages.Select(c => c.ToDto());
    }

    public static PropertyImageDto ToDto(this PropertyImage propertyImage)
    {
        return new PropertyImageDto
        {
            Id = propertyImage.Id,
            PropertyId = propertyImage.PropertyId,
            ImageUrl = propertyImage.ImageUrl,
            IsMain = propertyImage.IsMain
        };
    }

    public static IEnumerable<PropertyVideoDto> ToDto(this IEnumerable<PropertyVideo> propertyVideos)
    {
        return propertyVideos.Select(c => c.ToDto());
    }

    public static PropertyVideoDto ToDto(this PropertyVideo propertyVideo)
    {
        return new PropertyVideoDto
        {
            Id = propertyVideo.Id,
            PropertyId = propertyVideo.PropertyId,
            ThumbnailUrl = propertyVideo.ThumbnailUrl,
            VideoUrl = propertyVideo.VideoUrl
        };
    }

    public static IEnumerable<PropertyDto> ToDto(this IEnumerable<Property> dataModels)
    {
        if (dataModels == null) return null;
        return dataModels.Select(c => c.ToDto());
    }
}