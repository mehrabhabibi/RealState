using Npgsql.Replication;
using RealState.API.ViewModels.Property;
using RealState.Domain.DTOs.Properties;

namespace RealState.API.Mapping
{
    public static class PropertyMapper
    {
        public static IEnumerable<PropertyViewModel> ToViewModel(this IEnumerable<PropertyDto> propertyDtos)
        {
            return propertyDtos.Select(propertyDto => propertyDto.ToViewModel());
        }

        public static PropertyViewModel ToViewModel(this PropertyDto propertyDto)
        {
            return new PropertyViewModel
            {
                Id = propertyDto.Id,
                Title = propertyDto.Title,
                Description = propertyDto.Description,
                Address = propertyDto.Address,
                City = propertyDto.City,
                Country = propertyDto.Country,
                ZipCode = propertyDto.ZipCode,
                Price = propertyDto.Price,
                Bedrooms = propertyDto.Bedrooms,
                Type = propertyDto.Type,
                Status = propertyDto.Status,
                Details = propertyDto.Details.ToViewModel(),
                Images = propertyDto.Images.ToViewModel(),
                Videos = propertyDto.Videos.ToViewModel()
            };
        }

        public static PropertyDetailsViewModel ToViewModel(this PropertyDetailsDto propertyDetails)
        {
            return new PropertyDetailsViewModel
            {
                YearBuilt = propertyDetails.YearBuilt,
                SquareMeters = propertyDetails.SquareMeters,
                EnergyRating = propertyDetails.EnergyRating,
                Bathrooms = propertyDetails.Bathrooms,
                Floors = propertyDetails.Floors,
                FurnishingStatus = propertyDetails.FurnishingStatus,
                HasBalcony = propertyDetails.HasBalcony,
                HasGarden = propertyDetails.HasGarden,
                HasGym = propertyDetails.HasGym,
                HasParking = propertyDetails.HasParking,
                HasPool = propertyDetails.HasPool,
                AdditionalFeatures = propertyDetails.AdditionalFeatures
            };
        }

        public static IEnumerable<PropertyImageViewModel> ToViewModel(this IEnumerable<PropertyImageDto> imageDtos)
        {
            return imageDtos.Select(c => c.ToViewModel());
        }

        public static PropertyImageViewModel ToViewModel(this PropertyImageDto imageDto)
        {
            return new PropertyImageViewModel
            {
                IsMain = imageDto.IsMain,
                ImageUrl = imageDto.ImageUrl
            };
        }

        public static IEnumerable<PropertyVideoViewModel> ToViewModel(this IEnumerable<PropertyVideoDto> videoDtos)
        {
            return videoDtos.Select(c => c.ToViewModel());
        }

        public static PropertyVideoViewModel ToViewModel(this PropertyVideoDto videoDto)
        {
            return new PropertyVideoViewModel
            {
                VideoUrl = videoDto.VideoUrl,
                ThumbnailUrl = videoDto.ThumbnailUrl
            };
        }

        public static CreatePropertyDto ToDto(this CreatePropertyViewModel viewModel)
        {
            return new CreatePropertyDto
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Address = viewModel.Address,
                City = viewModel.City,
                Country = viewModel.Country,
                ZipCode = viewModel.ZipCode,
                Price = viewModel.Price,
                Bedrooms = viewModel.Bedrooms,
                Type = viewModel.Type,
                Status = viewModel.Status,
                Details = viewModel.Details.ToDto(),
                Images = viewModel.Images.ToDto(),
                Videos = viewModel.Videos.ToDto()
            };
        }

        public static CreatePropertyDetailsDto ToDto(this CreatePropertyDetailsViewModel viewModel)
        {
            return new CreatePropertyDetailsDto
            {
                YearBuilt = viewModel.YearBuilt,
                SquareMeters = viewModel.SquareMeters,
                EnergyRating = viewModel.EnergyRating,
                Bathrooms = viewModel.Bathrooms,
                Floors = viewModel.Floors,
                FurnishingStatus = viewModel.FurnishingStatus,
                HasBalcony = viewModel.HasBalcony,
                HasGarden = viewModel.HasGarden,
                HasGym = viewModel.HasGym,
                HasParking = viewModel.HasParking,
                HasPool = viewModel.HasPool,
                AdditionalFeatures = viewModel.AdditionalFeatures
            };
        }

        public static IEnumerable<CreatePropertyImageDto> ToDto(this IEnumerable<CreatePropertyImageViewModel> images)
        {
            return images.Select(c => c.ToDto());
        }

        public static CreatePropertyImageDto ToDto(this CreatePropertyImageViewModel image)
        {
            return new CreatePropertyImageDto
            {
                IsMain = image.IsMain,
                ImageUrl = image.ImageUrl
            };
        }

        public static IEnumerable<CreatePropertyVideoDto> ToDto(this IEnumerable<CreatePropertyVideoViewModel> videos)
        {
            return videos.Select(c => c.ToDto());
        }

        public static CreatePropertyVideoDto ToDto(this CreatePropertyVideoViewModel video)
        {
            return new CreatePropertyVideoDto
            {
                VideoUrl = video.VideoUrl,
                ThumbnailUrl = video.ThumbnailUrl
            };
        }

        public static PropertyDto ToDto(this PropertyViewModel viewModel)
        {
            return new PropertyDto
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Address = viewModel.Address,
                City = viewModel.City,
                Country = viewModel.Country,
                ZipCode = viewModel.ZipCode,
                Price = viewModel.Price,
                Bedrooms = viewModel.Bedrooms,
                Type = viewModel.Type,
                Status = viewModel.Status,
                Details = viewModel.Details.ToDto(),
                Images = viewModel.Images.ToDto(),
                Videos = viewModel.Videos.ToDto()
            };
        }

        public static PropertyDetailsDto ToDto(this PropertyDetailsViewModel viewModel)
        {
            return new PropertyDetailsDto
            {
                YearBuilt = viewModel.YearBuilt,
                SquareMeters = viewModel.SquareMeters,
                EnergyRating = viewModel.EnergyRating,
                Bathrooms = viewModel.Bathrooms,
                Floors = viewModel.Floors,
                FurnishingStatus = viewModel.FurnishingStatus,
                HasBalcony = viewModel.HasBalcony,
                HasGarden = viewModel.HasGarden,
                HasGym = viewModel.HasGym,
                HasParking = viewModel.HasParking,
                HasPool = viewModel.HasPool,
                AdditionalFeatures = viewModel.AdditionalFeatures
            };
        }

        public static IEnumerable<PropertyImageDto> ToDto(this IEnumerable<PropertyImageViewModel> images)
        {
            return images.Select(c => c.ToDto());
        }

        public static PropertyImageDto ToDto(this PropertyImageViewModel image)
        {
            return new PropertyImageDto
            {
                IsMain = image.IsMain,
                ImageUrl = image.ImageUrl
            };
        }

        public static IEnumerable<PropertyVideoDto> ToDto(this IEnumerable<PropertyVideoViewModel> videos)
        {
            return videos.Select(c => c.ToDto());
        }

        public static PropertyVideoDto ToDto(this PropertyVideoViewModel video)
        {
            return new PropertyVideoDto
            {
                VideoUrl = video.VideoUrl,
                ThumbnailUrl = video.ThumbnailUrl
            };
        }
    }
}