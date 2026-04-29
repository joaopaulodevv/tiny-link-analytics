namespace tiny_link_analytics.Models;
using AutoMapper;

public class ShortUrlProfile : Profile
{
    public ShortUrlProfile()
    {
        CreateMap<ShortUrl, ShortUrlResponseDto>();
        CreateMap<ShortUrlRequestDto, ShortUrl>();
    }
}
