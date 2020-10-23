using System;
using FluentAssertions;
using Mesi.Io.Clipboard.Domain.Clipboard.Models;
using Xunit;

namespace Mesi.Io.Clipboard.Domain.Test.Clipboard
{
    public class ClipboardEntryTest
    {
        private const string UserId = "user-id";
        private const string Content = "clipboard content";
        private static readonly DateTime TimeSTamp = DateTime.UtcNow;
        private readonly string Id = Guid.NewGuid().ToString();

        [Fact]
        public void ItShallCreateRequireUserId()
        {
            Action act1 = () => ClipboardEntry.New(string.Empty, Content, TimeSTamp);
            act1.Should().Throw<ArgumentException>();
            
            Action act2 = () => ClipboardEntry.Create(Id, string.Empty, Content, TimeSTamp, 500);
            act2.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void ItShallRequireContent()
        {
            Action act1 = () => ClipboardEntry.New(UserId, string.Empty, TimeSTamp);
            act1.Should().Throw<ArgumentException>();
            
            Action act2 = () => ClipboardEntry.Create(Id, UserId, string.Empty, TimeSTamp, 500);
            act2.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ItShallNotCreateEntryWithLongContent()
        {
            Action act = () => ClipboardEntry.New(UserId,
                "eLQdGDd82tBgySQvl0mpiSiBiFE7DHIRhyE80xHecIwxjkE22eAB0QPwcf3VNHmv7YpD4dKnkzp4fmVagXXGM5SJNkWNHcLc6JF92MbRvF2WcbnZIVk8gs6hKiaDGDL8lsHgvrpNx40LKT6duLPp5BPHCKk70vEx8zfF7kGnNgtPdZsOeijwxipk9twaJ782teeMgOF6VSpPrD22ukSMBv7wrCSqvO86PUMHvl7jGoq9Hj9CNjp9nE7R4JyCPEXnEU6aANIXQ2u2WjGOIGGtlICuZJ2BVxtL2pzSxI34WYQtGIl1kTsKkJpkuZu6jsopoQ8NoO8x9LEiRihVC8VBPX8GOkeo4Ir7MXlwSExJIT3J3vNPyBKn84f7fITQRMnhe70WZ6Fy04DyNDosFu5wk1w0B6gaMScOnwXU8RAywxYUaI81X2U8SmxgIGXfjcy5fgDWPKdWxi0HpHPJ5DlkDMzcdQxBmXM3N3aGeDSFw0FNnL84JJ4Ma",
                TimeSTamp);

            act.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void ItShallHaveContent()
        {
            // given
            var sut = ClipboardEntry.Create(Id, UserId, Content, TimeSTamp, 500);

            // when
            var content = sut.Content;

            // then
            content.Text.Should().Be(Content);
        }
    }
}